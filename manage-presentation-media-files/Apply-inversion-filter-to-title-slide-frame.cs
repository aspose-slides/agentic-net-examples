// -----------------------------------------------------------------------------
// Example: Apply inversion filter to title slide frame using C#
//
// Description:
// Demonstrates how to apply an inversion (alpha inverse) filter to a picture
// placed on the title slide of a PowerPoint presentation using C# and
// Aspose.Slides for .NET. The example creates a new presentation, inserts an
// image as a picture frame on the first slide, applies the inversion effect,
// and saves the result as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Inversion, Filter,
// Title Slide, Picture Frame, Image Transform
//
// Use Cases:
// - Automate applying an inversion filter to images on title slides.
// - Build .NET tools for PowerPoint presentation processing.
// - Generate or modify PPTX files with visual effects in C# applications.
// - Validate presentation workflows involving image effects.
// -----------------------------------------------------------------------------
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
