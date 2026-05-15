using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Add a math shape to the first slide
        IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 400, 100);

        // Retrieve the math paragraph from the shape
        IMathParagraph mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Build a simple equation: a + b = c
        mathParagraph.Add(new MathematicalText("a")
            .Join("+")
            .Join(new MathematicalText("b"))
            .Join("=")
            .Join(new MathematicalText("c")));

        // Export the MathML to a memory stream without modifying the presentation
        using (MemoryStream ms = new MemoryStream())
        {
            mathParagraph.WriteAsMathMl(ms);
            try
            {
                File.WriteAllBytes("equation.xml", ms.ToArray());
            }
            catch (Exception ex)
            {
                // Handle file write exceptions
                Console.WriteLine("Error writing MathML file: " + ex.Message);
            }
        }

        // Save the presentation
        try
        {
            presentation.Save("output.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other save errors
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }

        // Clean up resources
        presentation.Dispose();
    }
}