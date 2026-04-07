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
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load options with a primary default regular font (may be unavailable)
                LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
                loadOptions.DefaultRegularFont = "NonExistentPrimaryFont";

                // Load the presentation using the load options
                Presentation pres = new Presentation(inputPath, loadOptions);

                // Create a fallback rule that uses a secondary font for all Unicode characters
                IFontFallBackRulesCollection fallbackRules = new FontFallBackRulesCollection();
                IFontFallBackRule fallbackRule = new FontFallBackRule(0x0, 0x10FFFF, "Arial");
                fallbackRules.Add(fallbackRule);

                // Assign the fallback rules to the presentation's FontsManager
                pres.FontsManager.FontFallBackRulesCollection = fallbackRules;

                // Save the presentation
                pres.Save(outputPath, SaveFormat.Pptx);

                // Clean up
                pres.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}