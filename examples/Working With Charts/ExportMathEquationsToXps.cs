using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a mathematical shape to host the equation
        Aspose.Slides.IAutoShape mathShape = slide.Shapes.AddMathShape(0, 0, 500, 50);

        // Retrieve the math paragraph from the shape
        Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Create a fraction x / y
        Aspose.Slides.MathText.IMathFraction fraction = new Aspose.Slides.MathText.MathFraction(
            new Aspose.Slides.MathText.MathematicalText("x"),
            new Aspose.Slides.MathText.MathematicalText("y")
        );

        // Add the fraction as a math block to the paragraph
        mathParagraph.Add(new Aspose.Slides.MathText.MathBlock(fraction));

        // Save the presentation as XPS
        Aspose.Slides.Export.XpsOptions xpsOptions = new Aspose.Slides.Export.XpsOptions();
        pres.Save("ExportMathToXps.xps", Aspose.Slides.Export.SaveFormat.Xps, xpsOptions);
    }
}