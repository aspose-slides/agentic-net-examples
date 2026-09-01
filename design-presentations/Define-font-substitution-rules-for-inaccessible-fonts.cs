// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Define font substitution rules for inaccessible fonts using C#

//

// Description:

// Demonstrates how to define font substitution rules for inaccessible fonts 

// using Aspose.Slides for .NET. The example loads a PPTX file, creates a rule 

// that replaces a missing font with Arial when the source font is inaccessible, 

// assigns the rule to the presentation's FontsManager, and saves the modified 

// presentation. This pattern can be used to ensure proper font rendering in 

// PowerPoint files when original fonts are unavailable.

//

// Keywords:

// C#, Aspose.Slides, Font Substitution, Inaccessible Fonts, Presentation Processing, 

// PPTX, .NET, FontsManager, FontData, FontSubstRule

//

// Use Cases:

// - Automate definition of font substitution rules for inaccessible fonts.

// - Build C# tools that ensure consistent font rendering in PowerPoint presentations.

// - Integrate font fallback logic into .NET applications handling PPTX files.

// - Prepare presentations for environments where certain fonts may be missing.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace FontSubstitutionExample

{

    class Program

    {

        static void Main(string[] args)

        {

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

                // Load the presentation

                using (Presentation presentation = new Presentation(inputPath))

                {

                    // Create a new collection for font substitution rules

                    IFontSubstRuleCollection substitutionRules = new FontSubstRuleCollection();



                    // Define a rule: replace "MissingFont" with "Arial" when the source font is inaccessible

                    IFontData sourceFont = new FontData("MissingFont");

                    IFontData destFont = new FontData("Arial");

                    FontSubstRule rule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);



                    // Add the rule to the collection

                    substitutionRules.Add(rule);



                    // Assign the collection to the presentation's FontsManager

                    presentation.FontsManager.FontSubstRuleList = substitutionRules;



                    // Save the modified presentation

                    presentation.Save(outputPath, SaveFormat.Pptx);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The specified file format is not supported.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

