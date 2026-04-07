using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DefineFontSubstitution
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
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
                    // Get existing substitution rule list or create a new one
                    IFontSubstRuleCollection substRules = presentation.FontsManager.FontSubstRuleList;
                    if (substRules == null)
                    {
                        substRules = new FontSubstRuleCollection();
                        presentation.FontsManager.FontSubstRuleList = substRules;
                    }

                    // Define a substitution rule: replace "Arial" with "Times New Roman" when the source font is inaccessible
                    IFontData sourceFont = new FontData("Arial");
                    IFontData destFont = new FontData("Times New Roman");
                    FontSubstRule rule = new FontSubstRule(sourceFont, destFont, Aspose.Slides.FontSubstCondition.WhenInaccessible);

                    // Add the rule to the collection
                    substRules.Add(rule);

                    // Save the presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }

                Console.WriteLine("Presentation saved successfully to " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Format not supported.
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}