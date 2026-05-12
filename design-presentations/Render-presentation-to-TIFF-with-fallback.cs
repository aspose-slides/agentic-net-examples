using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesTiffFallback
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.tiff";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Set up font fallback rules
                    IFontFallBackRulesCollection fallbackRules = new FontFallBackRulesCollection();
                    fallbackRules.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
                    presentation.FontsManager.FontFallBackRulesCollection = fallbackRules;

                    // Configure TIFF options for high‑resolution output
                    TiffOptions tiffOptions = new TiffOptions();
                    tiffOptions.DpiX = 300;
                    tiffOptions.DpiY = 300;

                    // Save the presentation as TIFF using the specified options
                    presentation.Save(outputPath, SaveFormat.Tiff, tiffOptions);
                }

                Console.WriteLine("Presentation successfully saved as TIFF: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // The requested file format is not supported by Aspose.Slides.
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., loading errors, I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}