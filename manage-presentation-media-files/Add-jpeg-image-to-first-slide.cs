// -----------------------------------------------------------------------------
// Example: Add jpeg image to first slide using C#
//
// Description:
// Demonstrates how to add a JPEG image to the first slide of a new presentation using C# and Aspose.Slides for .NET. The example creates a presentation, loads a JPEG file from a data folder, inserts it as a picture frame on the first slide, and saves the result as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, JPEG, Jpeg, Image, First, Slide, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a JPEG image to the first slide of a presentation.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files with embedded images in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddImageExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define data directory and image file name
            string dataDir = "Data";
            string imageFileName = "image.jpg";

            // Ensure the data directory exists
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            // Build full image path
            string imagePath = Path.Combine(dataDir, imageFileName);

            // Verify that the image file exists
            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Image file not found: " + imagePath);
                return;
            }

            // Create a new presentation
            Presentation pres = new Presentation();

            try
            {
                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Load the image from file
                IImage img = Images.FromFile(imagePath);

                // Add the image to the presentation's image collection
                IPPImage imgx = pres.Images.AddImage(img);

                // Add a picture frame to the first slide
                slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0f, 0f, 300f, 200f, imgx);

                // Define output path
                string outPath = Path.Combine(dataDir, "output.pptx");

                // Save the presentation
                pres.Save(outPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // If the format is not supported, comment accordingly
                // Format not supported
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                // Dispose the presentation object
                pres.Dispose();
            }
        }
    }
}
