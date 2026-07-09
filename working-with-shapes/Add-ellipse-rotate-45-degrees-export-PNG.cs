using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main()
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add an ellipse shape
                Aspose.Slides.IAutoShape ellipse = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 100, 100, 200, 100);
                // Set rotation angle to 45 degrees
                ellipse.Rotation = 45f;

                // Export the slide as PNG
                using (Aspose.Slides.IImage slideImage = slide.GetImage())
                {
                    slideImage.Save("slide.png", Aspose.Slides.ImageFormat.Png);
                }

                // Save the presentation before exiting
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}