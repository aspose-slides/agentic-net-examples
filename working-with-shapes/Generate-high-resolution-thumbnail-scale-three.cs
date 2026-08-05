// -----------------------------------------------------------------------------
// Example: Generate high resolution thumbnail scale three using C#
//
// Description:
// Demonstrates how to generate high‑resolution thumbnails at a scale factor of three for each slide in a PowerPoint presentation using C# and Aspose.Slides for .NET. The example loads a PPTX file, creates JPEG images for every slide with increased resolution, and saves them to disk.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Generate, High, Resolution, Thumbnail, Scale Three, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate creation of high‑resolution slide thumbnails for preview or publishing.
// - Build C# utilities that extract slide images at enhanced quality.
// - Integrate slide thumbnail generation into .NET applications or CI pipelines.
// - Prepare assets for responsive web or mobile display where higher DPI is required.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the input presentation
        string inputPath = "input.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Scaling factor of three for high‑resolution thumbnails
            int scaleX = 3;
            int scaleY = scaleX;

            // Export each slide as a JPEG image with the specified scale
            foreach (Aspose.Slides.ISlide slide in presentation.Slides)
            {
                using (Aspose.Slides.IImage thumbnail = slide.GetImage(scaleX, scaleY))
                {
                    string imageFileName = string.Format("Slide_{0}.jpg", slide.SlideNumber);
                    thumbnail.Save(imageFileName, Aspose.Slides.ImageFormat.Jpeg);
                }
            }

            // Save the presentation before exiting (no modifications made)
            presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
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
