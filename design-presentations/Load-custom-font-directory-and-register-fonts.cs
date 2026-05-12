using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FontFallbackExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths
            string inputPath = "input.pptx";
            string outputPath = "output.png";
            string outputPresentationPath = "output.pptx";
            string fontsDirectory = "customfonts";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Verify fonts directory exists
            if (!Directory.Exists(fontsDirectory))
            {
                Console.WriteLine("Fonts directory does not exist: " + fontsDirectory);
                return;
            }

            try
            {
                // Load custom fonts from the specified directory
                string[] fontFolders = new string[] { fontsDirectory };
                FontsLoader.LoadExternalFonts(fontFolders);

                // Load presentation
                Presentation presentation = new Presentation(inputPath);

                // Create fallback rules collection
                IFontFallBackRulesCollection fallbackRules = new FontFallBackRulesCollection();

                // Example fallback rule: Unicode range 0x400-0x4FF uses "Times New Roman"
                FontFallBackRule rule = new FontFallBackRule(0x400, 0x4FF, "Times New Roman");
                fallbackRules.Add(rule);

                // Register fallback rules with the presentation's FontsManager
                presentation.FontsManager.FontFallBackRulesCollection = fallbackRules;

                // Render first slide to an image
                IImage slideImage = presentation.Slides[0].GetImage(1f, 1f);
                slideImage.Save(outputPath, ImageFormat.Png);
                slideImage.Dispose();

                // Save the presentation after applying fallback rules
                presentation.Save(outputPresentationPath, SaveFormat.Pptx);
                presentation.Dispose();

                // Clear loaded custom fonts from cache
                FontsLoader.ClearCache();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                // Format not supported
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}