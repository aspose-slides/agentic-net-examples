using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TextFrameRotationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a rectangle AutoShape
                IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);

                // Add a TextFrame with sample text
                autoShape.AddTextFrame("Rotated Text");

                // Access the TextFrame format and set a custom rotation angle
                ITextFrameFormat textFormat = autoShape.TextFrame.TextFrameFormat;
                textFormat.RotationAngle = 45f; // Rotate text by 45 degrees

                // Save the presentation
                presentation.Save("RotatedTextFrame.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}