using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine input ODP file path (use first argument or default)
            string inputPath = args.Length > 0 ? args[0] : "input.odp";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Prepare output directory for JPG files
            string outputDir = "ExportedJpg";
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            try
            {
                // Load the ODP presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Remove hidden slides (iterate backwards to avoid index issues)
                    for (int i = presentation.Slides.Count - 1; i >= 0; i--)
                    {
                        ISlide slide = presentation.Slides[i];
                        if (slide.Hidden)
                        {
                            slide.Remove();
                        }
                    }

                    // Save the modified presentation (still in ODP format) before exiting
                    string modifiedPath = "ModifiedWithoutHidden.odp";
                    presentation.Save(modifiedPath, SaveFormat.Odp);

                    // Export each remaining slide to a high‑resolution JPG
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        ISlide slide = presentation.Slides[i];
                        // Use scaling factors of 2 for higher resolution
                        IImage image = slide.GetImage(2f, 2f);
                        string jpgPath = Path.Combine(outputDir, $"slide_{i + 1}.jpg");
                        image.Save(jpgPath, ImageFormat.Jpeg);
                    }
                }
            }
            catch (PptxUnsupportedFormatException)
            {
                // The ODP format is not supported for the requested operation
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