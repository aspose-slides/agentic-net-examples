// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Clear fallback fonts and verify original rendering using C#

//

// Description:

// Demonstrates how to clear fallback font rules and verify the effect on font

// substitutions using Aspose.Slides for .NET. The example loads a presentation

// with a non‑existent default regular font, displays the current font

// substitutions, clears all fallback font rules, displays the updated

// substitutions, and saves the modified presentation.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clear, Fallback, Fonts, Verify,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate clearing of fallback fonts and observe substitution changes.

// - Build C# tools for PowerPoint presentation processing and validation.

// - Generate or transform PPTX files while managing font fallback behavior.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        var inputPath = "input.pptx";

        var outputPath = "output.pptx";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file not found.");

            return;

        }



        try

        {

            // Load presentation with a non‑existent default regular font

            var loadOptions = new LoadOptions();

            loadOptions.DefaultRegularFont = "NonExistentFont";



            using (var presentation = new Presentation(inputPath, loadOptions))

            {

                // Show current font substitutions

                Console.WriteLine("Font substitutions before clearing fallback rules:");

                foreach (var info in presentation.FontsManager.GetSubstitutions())

                {

                    Console.WriteLine($"{info.OriginalFontName} -> {info.SubstitutedFontName}");

                }



                // Clear fallback font rules

                var emptyRules = new FontFallBackRulesCollection();

                presentation.FontsManager.FontFallBackRulesCollection = emptyRules;



                // Show font substitutions after clearing fallback rules

                Console.WriteLine("Font substitutions after clearing fallback rules:");

                foreach (var info in presentation.FontsManager.GetSubstitutions())

                {

                    Console.WriteLine($"{info.OriginalFontName} -> {info.SubstitutedFontName}");

                }



                // Save the presentation

                presentation.Save(outputPath, SaveFormat.Pptx);

            }

        }

        catch (Aspose.Slides.PptxUnsupportedFormatException)

        {

            // Format not supported

            Console.WriteLine("The presentation format is not supported.");

        }

        catch (Exception ex)

        {

            Console.WriteLine($"An error occurred: {ex.Message}");

        }

    }

}

