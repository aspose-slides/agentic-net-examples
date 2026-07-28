// -----------------------------------------------------------------------------
// Example: Create slide thumbnails zip archive using C#
//
// Description:
// Demonstrates how to generate PNG thumbnails for each slide in a PowerPoint
// presentation and package them into a ZIP archive using Aspose.Slides for .NET.
// The example loads a PPTX file, creates 200x150 pixel thumbnails, stores each
// thumbnail as a separate entry in a ZIP file, and optionally saves a copy of
// the original presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Slide, Thumbnails, ZIP, Archive,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate creation of slide thumbnail collections for web previews.
// - Build .NET tools that bundle slide images into downloadable archives.
// - Integrate slide thumbnail generation into CI pipelines or reporting systems.
// - Validate and transform PPTX files while producing visual summaries.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ThumbnailZipExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output zip archive path
            string outputZipPath = "thumbnails.zip";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load presentation
                Presentation pres = new Presentation(inputPath);

                // Create zip archive for thumbnails
                using (FileStream zipToOpen = new FileStream(outputZipPath, FileMode.Create))
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                {
                    // Iterate through slides
                    for (int i = 0; i < pres.Slides.Count; i++)
                    {
                        ISlide slide = pres.Slides[i];
                        // Generate thumbnail with specific size 200x150
                        using (IImage image = slide.GetImage(new System.Drawing.Size(200, 150)))
                        {
                            // Prepare zip entry name
                            string entryName = $"slide_{i + 1}.png";
                            ZipArchiveEntry entry = archive.CreateEntry(entryName);
                            using (Stream entryStream = entry.Open())
                            {
                                // Save image to zip entry in PNG format
                                image.Save(entryStream, Aspose.Slides.ImageFormat.Png);
                            }
                        }
                    }
                }

                // Save presentation (as per requirement) before exit
                string tempSavePath = "temp_output.pptx";
                pres.Save(tempSavePath, SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
