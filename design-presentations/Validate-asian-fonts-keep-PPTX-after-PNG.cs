using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ValidateAsianFonts
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputFolder = "output";

            // Check if input file exists
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

            // Read original file bytes for later comparison
            byte[] originalBytes = File.ReadAllBytes(inputPath);

            try
            {
                // Load presentation with default Asian font setting
                LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
                loadOptions.DefaultAsianFont = "Arial Unicode MS";
                using (Presentation presentation = new Presentation(inputPath, loadOptions))
                {
                    // Export each slide to PNG using GetImage (GetThumbnail does not exist)
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        ISlide slide = presentation.Slides[i];
                        IImage image = slide.GetImage();
                        string pngPath = Path.Combine(outputFolder, $"slide_{i + 1}.png");
                        image.Save(pngPath, ImageFormat.Png);
                    }

                    // Save presentation before exit (no modifications made)
                    presentation.Save(inputPath, SaveFormat.Pptx);
                }

                // Verify that the original PPTX file has not changed
                byte[] afterBytes = File.ReadAllBytes(inputPath);
                bool unchanged = originalBytes.Length == afterBytes.Length;
                if (unchanged)
                {
                    for (int i = 0; i < originalBytes.Length && unchanged; i++)
                    {
                        if (originalBytes[i] != afterBytes[i])
                        {
                            unchanged = false;
                        }
                    }
                }

                Console.WriteLine(unchanged
                    ? "Validation succeeded: PPTX file unchanged after PNG export."
                    : "Validation failed: PPTX file was altered.");
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., network errors if external resources were used)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}