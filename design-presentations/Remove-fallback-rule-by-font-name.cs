// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Remove fallback rule by font name using C#

//

// Description:

// Demonstrates how to remove a specific font from fallback rules in a PowerPoint

// presentation using C# and Aspose.Slides for .NET. The example loads a PPTX,

// iterates through the font fallback rules, removes the specified font, and

// deletes any empty rules, then saves the updated presentation.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Remove, Fallback, Rule, Font, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Remove unwanted font fallback entries from existing presentations.

// - Prepare presentations for environments where certain fonts are unavailable.

// - Automate cleanup of font fallback configurations in batch processing.

// - Integrate font management into .NET PowerPoint automation tools.

// -----------------------------------------------------------------------------

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

