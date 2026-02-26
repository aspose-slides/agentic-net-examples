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

        // Add a math shape to the first slide
        Aspose.Slides.IAutoShape mathShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);

        // Retrieve the math paragraph from the shape
        Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Build the equation a + b = c
        mathParagraph.Add(
            new Aspose.Slides.MathText.MathematicalText("a")
                .Join("+")
                .Join(new Aspose.Slides.MathText.MathematicalText("b"))
                .Join("=")
                .Join(new Aspose.Slides.MathText.MathematicalText("c"))
        );

        // Export the first slide as a JPEG image
        Aspose.Slides.IImage slideImage = pres.Slides[0].GetImage();
        slideImage.Save("MathEquation.jpg", Aspose.Slides.ImageFormat.Jpeg);

        // Save the presentation
        pres.Save("MathEquation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}