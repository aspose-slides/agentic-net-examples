using System;
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a math shape to host the equation
            IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 300, 50);

            // Retrieve the MathParagraph from the first MathPortion
            IMathParagraph mathParagraph = (mathShape.TextFrame.Paragraphs[0].Portions[0] as MathPortion).MathParagraph;

            // Add a simple mathematical block (e.g., "x+y")
            MathBlock mathBlock = new MathBlock(new MathematicalText("x+y"));
            mathParagraph.Add(mathBlock);

            // Save the presentation
            string outputPath = "MathParagraphDemo.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle any unexpected errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}