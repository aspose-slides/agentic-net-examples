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
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add a mathematical shape to the first slide
        Aspose.Slides.IAutoShape mathShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);

        // Retrieve the math paragraph from the shape
        Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Construct the equation "a + b = c" using a MathBlock with a single IMathElement
        Aspose.Slides.MathText.MathBlock mathBlock = new Aspose.Slides.MathText.MathBlock(new Aspose.Slides.MathText.MathematicalText("a"));
        mathBlock.Join("+")
                .Join(new Aspose.Slides.MathText.MathematicalText("b"))
                .Join("=")
                .Join(new Aspose.Slides.MathText.MathematicalText("c"));

        // Add the constructed math block to the paragraph
        mathParagraph.Add(mathBlock);

        // Define output PDF path
        string outPath = "MathEquation.pdf";

        // Ensure the output directory exists
        string outDir = Path.GetDirectoryName(outPath);
        if (!String.IsNullOrEmpty(outDir) && !Directory.Exists(outDir))
        {
            Directory.CreateDirectory(outDir);
        }

        // Save the presentation as PDF preserving equation layout and fonts
        pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pdf);
    }
}