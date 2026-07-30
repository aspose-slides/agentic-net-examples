// -----------------------------------------------------------------------------
// Example: Link picture frame to external image using C#
//
// Description:
// Demonstrates how to create a picture frame in a PowerPoint presentation
// that links to an external image file without embedding the image data.
// The example uses Aspose.Slides for .NET to add a placeholder image to satisfy
// the AddPictureFrame requirement, then sets the picture's link path to an
// external image. The resulting PPTX contains a linked picture frame, which
// references the external file at runtime.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Link, Picture Frame, External Image,
// Presentation Processing, Office Automation, Linked Media
//
// Use Cases:
// - Automate creation of presentations with linked images to reduce file size.
// - Build .NET tools that reference external media for dynamic content updates.
// - Generate PPTX files where images are managed separately from the presentation.
// - Validate linked media workflows before publishing or distribution.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the external image file (will be linked, not embedded)
            string externalImagePath = @"C:\Images\external.jpg";

            // Optional placeholder image to satisfy AddPictureFrame requirement
            string placeholderImagePath = @"C:\Images\placeholder.png";

            // Verify that the external image file exists
            if (!File.Exists(externalImagePath))
            {
                Console.WriteLine("External image file does not exist: " + externalImagePath);
                return;
            }

            // Verify that the placeholder image file exists
            if (!File.Exists(placeholderImagePath))
            {
                Console.WriteLine("Placeholder image file does not exist: " + placeholderImagePath);
                return;
            }

            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Load placeholder image into the presentation's image collection
            Image placeholderImage = Image.FromFile(placeholderImagePath);
            IPPImage ppPlaceholderImage = presentation.Images.AddImage(placeholderImage);

            // Add a picture frame using the placeholder image
            IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                ShapeType.Rectangle,
                50f,   // X position
                150f,  // Y position
                ppPlaceholderImage.Width,
                ppPlaceholderImage.Height,
                ppPlaceholderImage);

            // Link the picture frame to the external image file (no embedding)
            pictureFrame.PictureFormat.Picture.LinkPathLong = externalImagePath;

            // Save the presentation
            string outputPath = @"C:\Output\LinkedImagePresentation.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();

            Console.WriteLine("Presentation saved to: " + outputPath);
        }
    }
}
