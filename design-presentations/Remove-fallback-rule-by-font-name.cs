using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveFallbackRuleByFontName
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation
            string inputPath = "input.pptx";
            // Path to the output presentation
            string outputPath = "output.pptx";
            // Font name to remove from fallback rules
            string fontToRemove = "Tahoma";

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
                    // Get the collection of fallback rules
                    IFontFallBackRulesCollection fallbackRules = presentation.FontsManager.FontFallBackRulesCollection;

                    // Iterate over a copy of the collection because we may modify it during iteration
                    for (int i = fallbackRules.Count - 1; i >= 0; i--)
                    {
                        IFontFallBackRule rule = fallbackRules[i];

                        // Check if the rule contains the target font
                        int fontIndex = rule.IndexOf(fontToRemove);
                        if (fontIndex >= 0)
                        {
                            // Remove the font from the rule
                            rule.Remove(fontToRemove);

                            // If the rule no longer contains any fonts, remove the entire rule
                            if (rule.Count == 0)
                            {
                                fallbackRules.Remove(rule);
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }

                Console.WriteLine("Fallback rule updated and presentation saved to: " + outputPath);
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Handle unsupported file format
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}