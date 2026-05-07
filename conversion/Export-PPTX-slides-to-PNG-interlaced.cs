using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportPngInterlaced
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine input file path
            string inputPath = "input.pptx";
            if (args.Length > 0)
            {
                inputPath = args[0];
            }

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Create output directory
            string outputDir = "output_png";
            Directory.CreateDirectory(outputDir);

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Export each slide as PNG
                    for (int i = 0; i < pres.Slides.Count; i++)
                    {
                        ISlide slide = pres.Slides[i];
                        // Generate full‑scale image
                        IImage image = slide.GetImage(1f, 1f);
                        string outPath = Path.Combine(outputDir, $"slide_{i + 1}.png");
                        // Save PNG image (interlaced option not directly exposed; PNG will be saved normally)
                        image.Save(outPath, ImageFormat.Png);
                        image.Dispose();
                    }

                    // Save the presentation before exiting (required by lifecycle rules)
                    string savedPresPath = Path.Combine(outputDir, "presentation_saved.pptx");
                    pres.Save(savedPresPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The requested format is not supported by the current Aspose.Slides version.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., network or I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}