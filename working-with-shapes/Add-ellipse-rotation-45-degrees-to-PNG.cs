using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddEllipseRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add an ellipse shape to the slide
                IAutoShape ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 100f, 100f, 200f, 150f);

                // Set rotation angle to 45 degrees
                ellipse.Rotation = 45f;

                // Export the slide as PNG
                try
                {
                    using (IImage slideImage = slide.GetImage())
                    {
                        slideImage.Save("SlideWithEllipse.png", ImageFormat.Png);
                    }
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                }

                // Save the presentation before exiting
                try
                {
                    presentation.Save("PresentationWithEllipse.pptx", SaveFormat.Pptx);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                }
            }
        }
    }
}