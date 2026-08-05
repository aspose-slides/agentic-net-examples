// -----------------------------------------------------------------------------
// Example: Convert all slides to JPEG 85 quality using C#
//
// Description:
// Demonstrates how to convert every slide in a PowerPoint presentation to a JPEG
// image with 85% quality using C# and Aspose.Slides for .NET. The example loads a
// PPTX file, iterates through all slides, renders each slide as a full‑scale image,
// and saves the images as JPEG files with the specified quality setting. It also
// ensures the input file exists and the output directory is created if needed.
// This pattern can be used to automate slide‑to‑image conversion workflows.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, JPEG, Convert, Slides, Jpeg,
// Quality, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate conversion of all slides in a presentation to JPEG images at 85% quality.
// - Build C# utilities for batch processing of PowerPoint files.
// - Generate image assets from slides for web publishing or documentation.
// - Integrate slide rendering into .NET applications with quality control.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchConvertSlides
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output directory for JPEG images
            string outputDir = "output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            try
            {
                // Load presentation
                Presentation presentation = new Presentation(inputPath);

                // Iterate through all slides and save each as JPEG with 85% quality
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    ISlide slide = presentation.Slides[i];
                    // Get full‑scale image of the slide
                    IImage image = slide.GetImage(1f, 1f);
                    // Build output file name
                    string outputPath = Path.Combine(outputDir, $"slide_{i + 1}.jpg");
                    // Save image as JPEG with quality = 85
                    image.Save(outputPath, Aspose.Slides.ImageFormat.Jpeg, 85);
                }

                // Save presentation before exiting (no modifications made)
                presentation.Save(inputPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Handle unsupported format scenario here
                Console.WriteLine("The presentation format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
