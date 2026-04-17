using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FontFallbackExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output folder for JPG images
            string outputFolder = "output_images";
            // Fallback font name
            string fallbackFont = "Arial";

            // Verify input file exists
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

            try
            {
                // Load presentation
                Presentation pres = new Presentation(inputPath);

                // Set font fallback rule to use the specified fallback font for all Unicode ranges
                IFontFallBackRulesCollection fallbackRules = new FontFallBackRulesCollection();
                fallbackRules.Add(new FontFallBackRule(0x0, 0xFFFF, fallbackFont));
                pres.FontsManager.FontFallBackRulesCollection = fallbackRules;

                // Export each slide to JPG
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    IImage image = pres.Slides[i].GetImage(1f, 1f);
                    string outputPath = Path.Combine(outputFolder, $"slide_{i + 1}.jpg");
                    image.Save(outputPath, Aspose.Slides.ImageFormat.Jpeg);
                    image.Dispose();
                }

                // Save the modified presentation
                pres.Save("output.pptx", SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}