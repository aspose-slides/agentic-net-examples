using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (Presentation presentation = new Presentation())
            {
                ISlide slide = presentation.Slides[0];

                // Add an ellipse shape
                IAutoShape ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 100, 100, 200, 100);
                // Rotate the ellipse by 45 degrees
                ellipse.Rotation = 45f;

                // Save the presentation
                presentation.Save("EllipsePresentation.pptx", SaveFormat.Pptx);

                // Export the slide as PNG
                using (IImage image = slide.GetImage())
                {
                    image.Save("Slide.png", Aspose.Slides.ImageFormat.Png);
                }
            }
        }
        catch (NotSupportedException ex)
        {
            // Format not supported
            Console.WriteLine("The requested format is not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}