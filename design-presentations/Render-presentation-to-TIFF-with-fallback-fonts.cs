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
            string inputPath = "input.pptx";
            string outputPath = "output.tiff";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                Presentation presentation = new Presentation(inputPath);

                // Create fallback rules collection
                IFontFallBackRulesCollection fallbackRules = new FontFallBackRulesCollection();
                fallbackRules.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

                // Assign fallback rules to the presentation
                presentation.FontsManager.FontFallBackRulesCollection = fallbackRules;

                // Configure TIFF options for high‑resolution rendering
                TiffOptions tiffOptions = new TiffOptions();
                tiffOptions.DpiX = 300;
                tiffOptions.DpiY = 300;

                // Save the presentation as TIFF
                presentation.Save(outputPath, SaveFormat.Tiff, tiffOptions);

                // Dispose the presentation
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine(ex.Message);
            }
        }
    }
}