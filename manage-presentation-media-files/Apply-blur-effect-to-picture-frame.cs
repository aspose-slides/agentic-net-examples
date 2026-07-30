// -----------------------------------------------------------------------------
// Example: Apply blur effect to picture frame using C#
//
// Description:
// Demonstrates how to apply blur effect to picture frame using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Blur, Effect, Picture, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate apply blur effect to picture frame.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Effects;

namespace BlurPictureExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define data directory and image file name
            string dataDir = Directory.GetCurrentDirectory();
            string imageFileName = "sample.jpg";
            string imagePath = Path.Combine(dataDir, imageFileName);

            // Verify that the image file exists
            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Image file not found: " + imagePath);
                return;
            }

            // Create a new presentation
            Presentation pres = new Presentation();

            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Load the image into the presentation's image collection
            FileStream imgStream = null;
            IPPImage img = null;
            try
            {
                imgStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
                img = pres.Images.AddImage(imgStream);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading image: " + ex.Message);
                return;
            }
            finally
            {
                if (imgStream != null)
                {
                    imgStream.Close();
                }
            }

            // Add a picture frame to the slide using the loaded image
            IPictureFrame pictureFrame = (IPictureFrame)slide.Shapes.AddPictureFrame(
                ShapeType.Rectangle, 50, 50, 400, 300, img);

            // Apply a blur effect to the picture
            IImageTransformOperationCollection imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
            // Radius = 5.0, Grow = true
            imageTransform.AddBlurEffect(5.0, true);

            // Save the presentation
            string outPath = Path.Combine(dataDir, "BlurredImagePresentation.pptx");
            try
            {
                pres.Save(outPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format exception
                // Format not supported
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }

            // Dispose the presentation
            pres.Dispose();
        }
    }
}
