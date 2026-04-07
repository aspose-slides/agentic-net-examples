using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            try
            {
                Presentation presentation;

                if (File.Exists(inputPath))
                {
                    presentation = new Presentation(inputPath);
                }
                else
                {
                    // Create a new presentation if the file does not exist
                    presentation = new Presentation();
                }

                // Get the existing fallback rules collection
                IFontFallBackRulesCollection fallbackRules = presentation.FontsManager.FontFallBackRulesCollection;

                // Create a new fallback rule for a Unicode range (example: Basic Latin)
                FontFallBackRule newRule = new FontFallBackRule(0x0020, 0x007F, "Arial");

                // Add two alternative fallback fonts
                newRule.AddFallBackFonts("Calibri");
                newRule.AddFallBackFonts("Times New Roman");

                // Add the rule to the collection
                fallbackRules.Add(newRule);

                // Assign the modified collection back (optional, as we modified in place)
                presentation.FontsManager.FontFallBackRulesCollection = fallbackRules;

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file I/O, network)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}