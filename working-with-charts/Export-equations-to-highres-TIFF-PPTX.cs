using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MathToTiff
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect two arguments: input PPTX path and output folder path
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: MathToTiff <input.pptx> <output_folder>");
                return;
            }

            string inputPath = args[0];
            string outputFolder = args[1];

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Error: Input file \"{inputPath}\" not found.");
                return;
            }

            // Verify output folder exists or create it
            if (!Directory.Exists(outputFolder))
            {
                try
                {
                    Directory.CreateDirectory(outputFolder);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: Unable to create output folder \"{outputFolder}\". {ex.Message}");
                    return;
                }
            }

            // Load presentation
            Presentation presentation = null;
            try
            {
                presentation = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: Failed to load presentation. {ex.Message}");
                return;
            }

            // Configure high‑resolution TIFF options
            TiffOptions tiffOptions = new TiffOptions();
            tiffOptions.DpiX = 300;
            tiffOptions.DpiY = 300;

            // Iterate through slides and export each as a TIFF image
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                ISlide slide = presentation.Slides[i];
                IImage tiffImage = null;
                try
                {
                    tiffImage = slide.GetImage(tiffOptions);
                    string outputPath = Path.Combine(outputFolder, $"slide_{i + 1}.tiff");
                    tiffImage.Save(outputPath, Aspose.Slides.ImageFormat.Tiff);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: Failed to export slide {i + 1}. {ex.Message}");
                }
                finally
                {
                    if (tiffImage != null)
                    {
                        tiffImage.Dispose();
                    }
                }
            }

            // Save presentation (no modifications, but required by rule)
            try
            {
                presentation.Save(inputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Warning: Failed to save presentation. {ex.Message}");
            }

            // Clean up
            presentation.Dispose();
        }
    }
}