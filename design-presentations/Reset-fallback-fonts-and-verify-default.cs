using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FontFallbackClearExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Clear all existing font fallback rules by assigning an empty collection
                IFontFallBackRulesCollection emptyRules = new FontFallBackRulesCollection();
                pres.FontsManager.FontFallBackRulesCollection = emptyRules;

                // Save the presentation to confirm default fonts are applied
                pres.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Fallback fonts cleared and default fonts applied. Saved to " + outputPath);

                pres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported file format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // The provided file format may not be supported by Aspose.Slides.
            }
        }
    }
}