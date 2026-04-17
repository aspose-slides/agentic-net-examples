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
            // Input presentation path
            string inputPath = "input.pptx";
            // Output PDF path
            string outputPdfPath = "output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Define a fallback rule for Korean Hangul range (U+AC00–U+D7AF)
                    // Font name can be any Hangul-supporting font, e.g., "Malgun Gothic"
                    IFontFallBackRule hangulRule = new FontFallBackRule(0xAC00u, 0xD7AFu, "Malgun Gothic");
                    // Add the rule to the presentation's FontsManager
                    IFontFallBackRulesCollection fallbackRules = presentation.FontsManager.FontFallBackRulesCollection;
                    fallbackRules.Add(hangulRule);
                    presentation.FontsManager.FontFallBackRulesCollection = fallbackRules;

                    // Set PDF options (optional: specify default regular font)
                    PdfOptions pdfOptions = new PdfOptions();
                    pdfOptions.DefaultRegularFont = "Malgun Gothic";

                    // Save as PDF with fallback rule applied
                    presentation.Save(outputPdfPath, SaveFormat.Pdf, pdfOptions);

                    // Optionally, save the modified presentation
                    presentation.Save("modified.pptx", SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}