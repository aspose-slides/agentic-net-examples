using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file paths
        string outputPresentationPath = "MathExport.pptx";
        string outputMathMlPath = "math.xml";

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add a math shape to the first slide
        Aspose.Slides.IAutoShape mathShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);

        // Get the math paragraph from the shape
        Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Build a simple equation: a + b = c
        mathParagraph.Add(
            new Aspose.Slides.MathText.MathematicalText("a")
                .Join("+")
                .Join(new Aspose.Slides.MathText.MathematicalText("b"))
                .Join("=")
                .Join(new Aspose.Slides.MathText.MathematicalText("c"))
        );

        // Export the math paragraph to MathML, handling possible exceptions
        try
        {
            using (FileStream stream = new FileStream(outputMathMlPath, FileMode.Create, FileAccess.Write))
            {
                mathParagraph.WriteAsMathMl(stream);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error exporting MathML: " + ex.Message);
        }

        // Save the presentation
        pres.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}