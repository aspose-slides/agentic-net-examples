using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

public class Program
{
    public static void Main(string[] args)
    {
        // Expect input and output file paths
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: Program <input.pptx> <output.xps>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Add a mathematical shape with an equation to ensure fidelity in XPS
        Aspose.Slides.IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);
        Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
        mathParagraph.Add(new Aspose.Slides.MathText.MathematicalText("a")
            .Join("+")
            .Join(new Aspose.Slides.MathText.MathematicalText("b"))
            .Join("=")
            .Join(new Aspose.Slides.MathText.MathematicalText("c")));

        // Save the presentation as XPS
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Xps);

        // Clean up
        presentation.Dispose();
    }
}