using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ApplyArabicFallbackFont
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pdf";

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
                    // Get the fallback rules collection from the FontsManager
                    IFontFallBackRulesCollection fallbackRules = presentation.FontsManager.FontFallBackRulesCollection;

                    // Add a fallback rule for Arabic script Unicode range (0x0600 - 0x06FF) using a common font
                    fallbackRules.Add(new FontFallBackRule(0x0600, 0x06FF, "Arial"));

                    // Assign the modified collection back (optional, as the collection is mutable)
                    presentation.FontsManager.FontFallBackRulesCollection = fallbackRules;

                    // Save the presentation as PDF
                    presentation.Save(outputPath, SaveFormat.Pdf);
                }

                Console.WriteLine("Presentation processed and saved to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported by Aspose.Slides.
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., I/O errors, licensing issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}