// -----------------------------------------------------------------------------
// Example: Insert high resolution image and generate thumbnails using C#
//
// Description:
// Demonstrates how to insert a high‑resolution image into a presentation slide
// and generate lower‑resolution thumbnail images for each slide using C# and
// Aspose.Slides for .NET. The example loads a template PPTX, adds the image as a
// full‑slide picture, creates JPEG thumbnails, saves them to a folder, and
// writes the updated presentation to a new file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Insert, High, Resolution, Image,
// Thumbnails, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate insertion of high‑resolution images into PowerPoint presentations.
// - Generate slide thumbnails for preview or indexing purposes.
// - Build .NET tools for PPTX manipulation and media handling.
// - Validate presentation content before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPresentationPath = Path.Combine(Directory.GetCurrentDirectory(), "template.pptx");
        string highResImagePath = Path.Combine(Directory.GetCurrentDirectory(), "highres.jpg");
        string outputPresentationPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
        string thumbnailsFolder = Path.Combine(Directory.GetCurrentDirectory(), "thumbnails");

        // Verify that required files exist
        if (!File.Exists(inputPresentationPath))
        {
            Console.WriteLine("Input presentation file not found.");
            return;
        }
        if (!File.Exists(highResImagePath))
        {
            Console.WriteLine("High‑resolution image file not found.");
            return;
        }

        // Ensure the thumbnails directory exists
        if (!Directory.Exists(thumbnailsFolder))
        {
            Directory.CreateDirectory(thumbnailsFolder);
        }

        try
        {
            // Load the presentation
            Presentation presentation = new Presentation(inputPresentationPath);

            // Insert the high‑resolution image into the first slide
            IImage highResImage = Images.FromFile(highResImagePath);
            IPPImage pptImage = presentation.Images.AddImage(highResImage);
            ISlide firstSlide = presentation.Slides[0];
            firstSlide.Shapes.AddPictureFrame(
                ShapeType.Rectangle,
                0,
                0,
                presentation.SlideSize.Size.Width,
                presentation.SlideSize.Size.Height,
                pptImage);

            // Generate lower‑resolution thumbnails for all slides
            int scaleX = 200; // desired thumbnail width scaling factor
            int scaleY = 200; // desired thumbnail height scaling factor (same as width for simplicity)
            foreach (ISlide slide in presentation.Slides)
            {
                using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
                {
                    string thumbnailPath = Path.Combine(thumbnailsFolder,
                        string.Format("Slide_{0}.jpg", slide.SlideNumber));
                    thumbnail.Save(thumbnailPath, Aspose.Slides.ImageFormat.Jpeg);
                }
            }

            // Save the modified presentation
            presentation.Save(outputPresentationPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
