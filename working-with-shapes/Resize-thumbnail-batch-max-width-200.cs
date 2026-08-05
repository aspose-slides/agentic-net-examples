// -----------------------------------------------------------------------------
// Example: Resize thumbnail batch max width 200 using C#
//
// Description:
// Demonstrates how to generate thumbnail images for each slide in a PowerPoint
// presentation with a maximum width of 200 pixels using Aspose.Slides for .NET.
// The example loads a PPTX file, calculates the scaling factor based on the
// presentation width, creates JPEG thumbnails for all slides, saves them to a
// folder, and optionally saves a copy of the original presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Resize, Thumbnail, Batch, 
// Width, Presentation Processing, Office Automation
//
// Use Cases:
// - Generate a set of uniformly sized slide thumbnails for web galleries.
// - Automate batch thumbnail creation in CI/CD pipelines.
// - Build .NET utilities that need preview images of presentations.
// - Prepare assets for documentation or e‑learning platforms.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputDir = "Thumbnails";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            float desiredWidth = 200f;
            float originalWidth = presentation.SlideSize.Size.Width;
            float scale = desiredWidth / originalWidth;

            foreach (Aspose.Slides.ISlide slide in presentation.Slides)
            {
                using (Aspose.Slides.IImage thumbnail = slide.GetImage(scale, scale))
                {
                    string imageFileName = Path.Combine(outputDir, string.Format("Slide_{0}.jpg", slide.SlideNumber));
                    thumbnail.Save(imageFileName, Aspose.Slides.ImageFormat.Jpeg);
                }
            }

            // Save presentation before exit (unchanged)
            string savedPath = Path.Combine(outputDir, "Copy.pptx");
            presentation.Save(savedPath, Aspose.Slides.Export.SaveFormat.Pptx);
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
