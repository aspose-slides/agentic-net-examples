using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle auto shape to the slide
            Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 200);

            // Add a text frame with long text that may overflow
            Aspose.Slides.ITextFrame textFrame = shape.AddTextFrame(
                "This is a very long text that will overflow the shape boundaries if not trimmed or autofitted. " +
                "It should demonstrate how to reduce overflowing text within a PPTX slide using Aspose.Slides.");

            // Set autofit mode to Normal to shrink text on overflow
            Aspose.Slides.ITextFrameFormat textFrameFormat = textFrame.TextFrameFormat;
            textFrameFormat.AutofitType = Aspose.Slides.TextAutofitType.Normal;

            // Ensure text wraps within the frame
            textFrameFormat.WrapText = Aspose.Slides.NullableBool.True;

            // Save the presentation as PPTX
            string outputPath = "TrimmedText.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}