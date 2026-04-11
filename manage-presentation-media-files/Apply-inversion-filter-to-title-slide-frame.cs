using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Effects;

namespace InversionFilterExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input image path
            string imagePath = "input.jpg";
            // Output presentation path
            string outputPath = "output.pptx";

            // Verify that the image file exists
            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Image file does not exist: " + imagePath);
                return;
            }

            try
            {
                // Create a new presentation
                Presentation pres = new Presentation();

                // Read image bytes
                byte[] imageBytes = File.ReadAllBytes(imagePath);

                // Add image to the presentation's image collection
                Aspose.Slides.IPPImage img = pres.Images.AddImage(imageBytes);

                // Get the first slide (title slide)
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Add picture frame with the image
                Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                    ShapeType.Rectangle,
                    0,
                    0,
                    img.Width,
                    img.Height,
                    img);

                // Apply inversion filter (alpha inverse effect)
                pictureFrame.PictureFormat.Picture.ImageTransform.AddAlphaInverseEffect();

                // Save the presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Handle unsupported format scenario
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}