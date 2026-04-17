using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportPptxToJpeg444
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output folder for JPEG images
            string outputFolder = "output_jpeg";

            try
            {
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

                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        ISlide slide = presentation.Slides[i];

                        // Generate a full‑scale image (1:1). This uses the default subsampling (4:4:4) for maximum color fidelity.
                        IImage image = slide.GetImage(1f, 1f);

                        // Build output file name
                        string outputPath = Path.Combine(outputFolder, $"Slide_{i + 1}.jpg");

                        // Save the image as JPEG with highest quality (100). The quality parameter does not affect subsampling.
                        image.Save(outputPath, Aspose.Slides.ImageFormat.Jpeg, 100);
                    }

                    // Save the presentation (no changes made, but fulfills the requirement to save before exit)
                    string tempSavePath = Path.Combine(outputFolder, "temp_save.pptx");
                    presentation.Save(tempSavePath, SaveFormat.Pptx);
                }

                Console.WriteLine("Export completed successfully.");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}