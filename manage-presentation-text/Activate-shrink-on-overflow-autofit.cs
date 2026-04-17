using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        // Add a rectangle auto shape
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
        // Add a text frame with sample text
        shape.AddTextFrame("This is a long text that should shrink on overflow if it does not fit within the shape boundaries.");
        // Access the text frame
        Aspose.Slides.ITextFrame txtFrame = shape.TextFrame;
        // Activate shrink‑on‑overflow autofit mode
        txtFrame.TextFrameFormat.AutofitType = Aspose.Slides.TextAutofitType.Normal;
        // Set text color to black
        Aspose.Slides.IParagraph para = txtFrame.Paragraphs[0];
        Aspose.Slides.IPortion portion = para.Portions[0];
        portion.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;
        // Save the presentation
        presentation.Save("ShrinkOnOverflow.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        // Clean up
        presentation.Dispose();
    }
}