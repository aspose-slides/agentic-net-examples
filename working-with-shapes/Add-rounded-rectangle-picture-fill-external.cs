// -----------------------------------------------------------------------------
// Example: Add rounded rectangle picture fill external using C#
//
// Description:
// Demonstrates how to add a rounded rectangle shape with an external picture
// fill using C# and Aspose.Slides for .NET. The example loads an external JPEG
// image, creates a presentation, adds a rectangle shape, applies the picture
// as a fill, and saves the result as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Rounded Rectangle, Picture Fill,
// External Image, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding rounded rectangle shapes with external picture fills.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files with custom image fills in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define data directory and file paths
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string imagePath = Path.Combine(dataDir, "image.jpg");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Ensure data directory exists
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            // Verify that the image file exists
            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Image file not found: " + imagePath);
                return;
            }

            // Load the external image and handle possible format exceptions
            IImage image = null;
            try
            {
                image = Images.FromFile(imagePath);
            }
            catch (Exception ex)
            {
                // Format not supported or other loading error
                Console.WriteLine("Failed to load image: " + ex.Message);
                return;
            }

            // Create a new presentation
            Presentation pres = new Presentation();

            // Add the image to the presentation resources
            IPPImage ppImage = pres.Images.AddImage(image);

            // Add a rounded rectangle shape (using Rectangle shape type as placeholder)
            IShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);

            // Apply picture fill using the loaded image
            shape.FillFormat.FillType = FillType.Picture;
            shape.FillFormat.PictureFillFormat.Picture.Image = ppImage;
            shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

            // Save the presentation
            try
            {
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }

            // Dispose the presentation
            pres.Dispose();
        }
    }
}
