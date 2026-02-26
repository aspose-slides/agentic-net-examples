using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add a mathematical shape to host the equation
        Aspose.Slides.IAutoShape mathShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);

        // Retrieve the math paragraph from the shape
        Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Create a fraction (x / y) and wrap it in a MathBlock
        Aspose.Slides.MathText.IMathFraction fraction = new Aspose.Slides.MathText.MathFraction(
            new Aspose.Slides.MathText.MathematicalText("x"),
            new Aspose.Slides.MathText.MathematicalText("y"));
        Aspose.Slides.MathText.MathBlock fractionBlock = new Aspose.Slides.MathText.MathBlock(fraction);

        // Add the fraction block to the paragraph
        mathParagraph.Add(fractionBlock);

        // Build a second equation: c = a² + b²
        Aspose.Slides.MathText.IMathBlock equationBlock = new Aspose.Slides.MathText.MathBlock(
            new Aspose.Slides.MathText.MathematicalText("c"))
            .Join("=")
            .Join(new Aspose.Slides.MathText.MathematicalText("a").SetSuperscript("2"))
            .Join("+")
            .Join(new Aspose.Slides.MathText.MathematicalText("b").SetSuperscript("2"));

        // Add the equation block to the paragraph
        mathParagraph.Add(equationBlock);

        // Save the presentation
        pres.Save("MathEquations.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}