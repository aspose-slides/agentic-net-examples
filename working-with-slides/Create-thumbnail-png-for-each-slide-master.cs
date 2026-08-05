// -----------------------------------------------------------------------------
// Example: Create thumbnail png for each slide master using C#
//
// Description:
// Demonstrates how to create a PNG thumbnail for each slide master in a PowerPoint
// presentation using C# and Aspose.Slides for .NET. The example loads a PPTX file,
// iterates through all master slides, generates a thumbnail image for each master,
// and saves the images to a specified output folder. This pattern can be used to
// automate PPTX workflows, validate presentation designs, or integrate slide‑master
// processing into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Thumbnail, Slide Master,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate creation of PNG thumbnails for each slide master.
// - Build C# tools for PowerPoint presentation analysis and documentation.
// - Generate visual previews of master slide designs in .NET applications.
// - Validate and compare master slide layouts before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideMasterThumbnailGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output folder for master thumbnails
            string outputFolder = "MasterThumbnails";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            try
            {
                // Load presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Iterate through each master slide
                    for (int index = 0; index < pres.Masters.Count; index++)
                    {
                        IMasterSlide master = pres.Masters[index];

                        // Generate thumbnail for the master slide (scale 1.0 = original size)
                        using (Image thumbnail = master.GetThumbnail(1.0f, 1.0f))
                        {
                            string outputPath = Path.Combine(outputFolder, $"Master_{index}.png");
                            thumbnail.Save(outputPath, ImageFormat.Png);
                            Console.WriteLine($"Saved thumbnail for master {index} to {outputPath}");
                        }
                    }
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported by Aspose.Slides.
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file access issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
