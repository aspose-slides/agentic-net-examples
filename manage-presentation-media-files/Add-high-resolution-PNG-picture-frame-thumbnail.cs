// -----------------------------------------------------------------------------
// Example: Add high resolution PNG picture frame thumbnail using C#
//
// Description:
// Demonstrates how to add a high‑resolution PNG picture frame to a presentation
// and downscale it to a thumbnail size using Aspose.Slides for .NET. The example
// creates a new PPTX file, inserts a picture frame containing the PNG image,
// applies relative scaling to produce a thumbnail, and saves the result.
// This pattern can be used to automate thumbnail generation for high‑resolution
// images within PowerPoint presentations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, High Resolution, Picture Frame,
// Thumbnail, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate creation of picture frame thumbnails from high‑resolution PNG images.
// - Build C# tools for PowerPoint presentation processing that include image scaling.
// - Generate or transform PPTX files with embedded thumbnails in .NET applications.
// - Validate image handling workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddPictureFrameExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define paths
            string dataDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string inputImagePath = Path.Combine(dataDirectory, "highres.png");
            string outputPresentationPath = Path.Combine(dataDirectory, "output.pptx");

            // Ensure data directory exists
            if (!Directory.Exists(dataDirectory))
            {
                Directory.CreateDirectory(dataDirectory);
            }

            // Verify input image exists
            if (!File.Exists(inputImagePath))
            {
                Console.WriteLine("Input image file not found: " + inputImagePath);
                return;
            }

            // Create a new presentation
            Presentation presentation = new Presentation();

            try
            {
                // Load high‑resolution image
                IImage highResImage = Images.FromFile(inputImagePath);
                // Add image to presentation resources
                IPPImage presentationImage = presentation.Images.AddImage(highResImage);
                // Add picture frame to the first slide
                IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(
                    ShapeType.Rectangle,
                    50f,   // X position
                    50f,   // Y position
                    600f,  // Width
                    400f,  // Height
                    presentationImage);

                // Downscale to thumbnail size (e.g., 20% of original)
                pictureFrame.RelativeScaleWidth = 0.2f;
                pictureFrame.RelativeScaleHeight = 0.2f;

                // Save the presentation
                presentation.Save(outputPresentationPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + outputPresentationPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
            }
            finally
            {
                // Ensure resources are released
                presentation.Dispose();
            }
        }
    }
}
