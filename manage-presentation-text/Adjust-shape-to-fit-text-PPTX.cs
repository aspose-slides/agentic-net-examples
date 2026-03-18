using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a rectangle auto shape
                Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 50, 50, 300, 100);

                // Add a text frame with sample text
                autoShape.AddTextFrame("This is a sample text that will cause the shape to resize automatically to fit its content.");

                // Set autofit mode to resize shape based on text
                Aspose.Slides.ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
                textFrameFormat.AutofitType = Aspose.Slides.TextAutofitType.Shape;

                // Save the presentation
                presentation.Save("AutoFitShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}