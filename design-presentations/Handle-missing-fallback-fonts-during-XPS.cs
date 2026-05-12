using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FontFallbackXpsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.xps";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                // Create fallback rules collection
                Aspose.Slides.IFontFallBackRulesCollection rules = new Aspose.Slides.FontFallBackRulesCollection();

                // Example rule: Unicode range for Cyrillic characters with fallback fonts
                Aspose.Slides.FontFallBackRule cyrillicRule = new Aspose.Slides.FontFallBackRule(0x0400, 0x04FF, "Arial");
                // Add an additional fallback font
                cyrillicRule.AddFallBackFonts("Times New Roman");
                rules.Add(cyrillicRule);

                // Validate that fallback fonts are defined
                if (cyrillicRule.Count == 0)
                {
                    throw new Exception("Missing fallback fonts for the defined Unicode range.");
                }

                // Assign the rules to the presentation's FontsManager
                pres.FontsManager.FontFallBackRulesCollection = rules;

                // Save the presentation to XPS format
                pres.Save(outputPath, SaveFormat.Xps);

                // Dispose the presentation
                pres.Dispose();

                Console.WriteLine("Presentation successfully saved to XPS: " + outputPath);
            }
            catch (NotSupportedException ex)
            {
                // Handle unsupported format exception
                Console.WriteLine("Error: The file format is not supported. " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling with descriptive message
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}