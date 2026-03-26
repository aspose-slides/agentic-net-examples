using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Add a math shape to the first slide
        IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);

        // Retrieve the math paragraph from the shape
        IMathParagraph mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Construct the equation: a + b = c
        mathParagraph.Add(new MathematicalText("a")
            .Join("+")
            .Join(new MathematicalText("b"))
            .Join("=")
            .Join(new MathematicalText("c")));

        // Configure XPS options to preserve equation fidelity
        XpsOptions options = new XpsOptions();
        options.SaveMetafilesAsPng = true;
        options.DrawSlidesFrame = true;

        // Define output file path
        string outputPath = "MathEquation.xps";

        // Save the presentation as XPS with the specified options
        presentation.Save(outputPath, SaveFormat.Xps, options);

        // Clean up resources
        presentation.Dispose();
    }
}