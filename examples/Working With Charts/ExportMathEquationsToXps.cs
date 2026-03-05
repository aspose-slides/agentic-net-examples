using System;
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Export;

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

        // Build a math block representing the equation "a + b = c"
        Aspose.Slides.MathText.IMathElement equationElement = new Aspose.Slides.MathText.MathematicalText("a")
            .Join("+")
            .Join(new Aspose.Slides.MathText.MathematicalText("b"))
            .Join("=")
            .Join(new Aspose.Slides.MathText.MathematicalText("c"));

        // Add the math block to the paragraph (explicit cast resolves constructor ambiguity)
        mathParagraph.Add(new Aspose.Slides.MathText.MathBlock((Aspose.Slides.MathText.IMathElement)equationElement));

        // Save the presentation as XPS
        pres.Save("MathEquation.xps", Aspose.Slides.Export.SaveFormat.Xps);
    }
}