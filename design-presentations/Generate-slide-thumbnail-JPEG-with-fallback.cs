using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideThumbnailGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output directory for thumbnails
            string outputDir = "thumbnails";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Set up font fallback rules
                    IFontFallBackRulesCollection rules = new FontFallBackRulesCollection();
                    // Example rule: fallback for Cyrillic range to Times New Roman
                    rules.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
                    pres.FontsManager.FontFallBackRulesCollection = rules;

                    // Generate JPEG thumbnails for each slide
                    int slideIndex = 0;
                    while (slideIndex < pres.Slides.Count)
                    {
                        IImage image = pres.Slides[slideIndex].GetImage(1f, 1f);
                        string outputPath = Path.Combine(outputDir, $"slide_{slideIndex + 1}.jpg");
                        image.Save(outputPath, Aspose.Slides.ImageFormat.Jpeg);
                        image.Dispose();
                        slideIndex++;
                    }

                    // Save the presentation before exiting
                    pres.Save("output_with_fallback.pptx", SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}