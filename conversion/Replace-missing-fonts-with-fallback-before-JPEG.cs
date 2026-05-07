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
            // Input and output paths
            string inputPath = "input.pptx";
            string outputPptxPath = "output.pptx";
            string outputDir = "output_images";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                Presentation presentation = new Presentation(inputPath);

                // Set fallback font for missing characters (e.g., Arial)
                IFontFallBackRulesCollection fallbackRules = new FontFallBackRulesCollection();
                fallbackRules.Add(new FontFallBackRule(0x0, 0xFFFF, "Arial"));
                presentation.FontsManager.FontFallBackRulesCollection = fallbackRules;

                // Ensure output directory exists
                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                // Export each slide to JPG
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    IImage slideImage = presentation.Slides[i].GetImage(1f, 1f);
                    string slidePath = Path.Combine(outputDir, $"slide_{i + 1}.jpg");
                    slideImage.Save(slidePath, Aspose.Slides.ImageFormat.Jpeg);
                    slideImage.Dispose();
                }

                // Save the modified presentation before exiting
                presentation.Save(outputPptxPath, SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // TODO: Add handling for unsupported file formats if needed
            }
        }
    }
}