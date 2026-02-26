using System;

namespace PresentationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle AutoShape
            Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 30, 30, 350, 100);

            // Add a text frame with sample text
            autoShape.AddTextFrame("This is a sample text that will be wrapped within the shape's margins.");

            // Access the text frame format
            Aspose.Slides.ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;

            // Enable text wrapping
            textFrameFormat.WrapText = Aspose.Slides.NullableBool.True;

            // Save the presentation
            presentation.Save("WrappedTextPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}