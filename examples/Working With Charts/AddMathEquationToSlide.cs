using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Output file path
        string outPath = "MathEquation.pptx";

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add a math shape to the first slide
        Aspose.Slides.IAutoShape mathShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);

        // Get the math paragraph from the shape
        Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Build the math equation: c = a² + b²
        Aspose.Slides.MathText.IMathBlock mathBlock = new Aspose.Slides.MathText.MathematicalText("c")
            .Join("=")
            .Join(new Aspose.Slides.MathText.MathematicalText("a").SetSuperscript("2"))
            .Join("+")
            .Join(new Aspose.Slides.MathText.MathematicalText("b").SetSuperscript("2"));

        // Add the math block to the paragraph
        mathParagraph.Add(mathBlock);

        // Save the presentation
        pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}