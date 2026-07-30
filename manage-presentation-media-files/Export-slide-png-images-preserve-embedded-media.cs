// -----------------------------------------------------------------------------
// Example: Export slide PNG images while preserving embedded media using C#
//
// Description:
// Demonstrates how to export each slide of a PowerPoint presentation as a high‑resolution PNG image
// and then save the presentation to retain any embedded media using Aspose.Slides for .NET.
// The example includes loading a PPTX file, creating an output folder, scaling the images,
// exporting them, and finally saving the presentation unchanged to preserve embedded media.
// This pattern can be used in console applications for automated slide image extraction
// and media preservation tasks.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Export, Slide, Images, Preserve, Embedded Media,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of high‑resolution slide images while keeping embedded media intact.
// - Build C# utilities for PowerPoint presentation processing and archival.
// - Generate PNG assets from PPTX files for web or documentation purposes.
// - Ensure embedded audio, video, or other media remain functional after processing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideExportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output folder for PNG images
            string outputFolder = "SlideImages";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Create output directory if it does not exist
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            try
            {
                // Load presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // High‑resolution scaling factors (e.g., 2x)
                float scaleX = 2f;
                float scaleY = 2f;

                // Export each slide as PNG
                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    using (Aspose.Slides.IImage image = slide.GetImage(scaleX, scaleY))
                    {
                        string imageFileName = Path.Combine(outputFolder,
                            string.Format("Slide_{0}.png", slide.SlideNumber));
                        image.Save(imageFileName, Aspose.Slides.ImageFormat.Png);
                    }
                }

                // Save presentation (preserve any changes or embedded media references)
                string savedPresentationPath = "output_preservation.pptx";
                presentation.Save(savedPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported for this operation.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
