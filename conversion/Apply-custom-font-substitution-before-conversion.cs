// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Apply custom font substitution before conversion using C#

//

// Description:

// Demonstrates how to load a PowerPoint presentation, define a custom font

// substitution rule (e.g., replace Arial with Times New Roman) using the

// FontsManager, and save the modified presentation. This standalone console

// application shows the necessary Aspose.Slides for .NET steps to ensure

// correct font rendering during conversion or further processing.

//

// Keywords:

// C#, Aspose.Slides for .NET, PowerPoint, PPTX, Font Substitution, FontsManager,

// FontData, FontSubstRule, Presentation Processing, Office Automation

//

// Use Cases:

// - Ensure missing fonts are substituted before converting or rendering PPTX files.

// - Automate font replacement in batch PowerPoint processing tools.

// - Build .NET utilities that prepare presentations for publishing with consistent fonts.

// - Integrate custom font handling into larger document workflow pipelines.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

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

                // Create a font substitution rule: replace "Arial" with "Times New Roman"

                IFontData sourceFont = new FontData("Arial");

                IFontData destFont = new FontData("Times New Roman");

                FontSubstRule substitutionRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.Always);



                // Add the substitution rule to the FontsManager

                presentation.FontsManager.FontSubstRuleList.Add(substitutionRule);



                // Save the modified presentation

                presentation.Save(outputPath, SaveFormat.Pptx);

            }

        }

        catch (NotSupportedException)

        {

            // Format not supported

        }

        catch (Exception ex)

        {

            // Handle other exceptions (e.g., file access issues)

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

