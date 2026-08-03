// -----------------------------------------------------------------------------
// Example: Link picture frame to cloud image url using C#
//
// Description:
// Demonstrates how to download an image from a cloud URL and embed it into a
// picture frame in a PowerPoint presentation using C# and Aspose.Slides for .NET.
// The example shows the required presentation-processing steps for PowerPoint
// files and produces the requested output in a standalone console application.
// Developers can use this pattern to automate PPTX workflows, validate results,
// or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Link, Picture, Frame, Cloud,
// Image, Download, Presentation Processing, Office Automation
//
// Use Cases:
// - Embed external images from URLs into PPTX files.
// - Automate adding cloud-hosted images to slides.
// - Build C# tools for dynamic PowerPoint presentation generation.
// - Validate image integration before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define data directory
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            if (!Directory.Exists(dataDir))
                Directory.CreateDirectory(dataDir);

            // Cloud image URL
            string imageUrl = "https://example.com/sample-image.jpg";

            // Download image bytes
            byte[] imageBytes;
            try
            {
                using (WebClient client = new WebClient())
                {
                    imageBytes = client.DownloadData(imageUrl);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to download image: " + ex.Message);
                return;
            }

            // Create a new presentation
            Presentation pres = new Presentation();

            // Add image to presentation's image collection
            IPPImage img = pres.Images.AddImage(imageBytes);

            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Add picture frame using the downloaded image
            IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                ShapeType.Rectangle,
                50,    // X position
                50,    // Y position
                img.Width,
                img.Height,
                img);

            // Save the presentation
            string outPath = Path.Combine(dataDir, "CloudImagePresentation.pptx");
            pres.Save(outPath, SaveFormat.Pptx);

            // Dispose presentation
            pres.Dispose();

            Console.WriteLine("Presentation saved to: " + outPath);
        }
    }
}
