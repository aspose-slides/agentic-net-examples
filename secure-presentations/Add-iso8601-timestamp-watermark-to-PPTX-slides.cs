using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation pres = new Presentation();

        // Add a blank slide
        ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

        // Get the first master slide
        IMasterSlide master = pres.Masters[0];

        // Add a rectangle shape that covers the whole slide as a watermark
        IAutoShape watermarkShape = master.Shapes.AddAutoShape(
            ShapeType.Rectangle,
            0,
            0,
            pres.SlideSize.Size.Width,
            pres.SlideSize.Size.Height);

        // Create ISO 8601 timestamp
        string timestamp = DateTime.UtcNow.ToString("o");

        // Add the timestamp text to the shape
        watermarkShape.AddTextFrame(timestamp);
        watermarkShape.TextFrame.TextFrameFormat.CenterText = NullableBool.True;

        // Make the shape and its border transparent
        watermarkShape.FillFormat.FillType = FillType.NoFill;
        watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;

        // Save the presentation
        pres.Save("WatermarkedPresentation.pptx", SaveFormat.Pptx);
    }
}