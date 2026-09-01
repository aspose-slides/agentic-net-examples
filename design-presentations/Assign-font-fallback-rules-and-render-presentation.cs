// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Assign font fallback rules and render presentation using C#

//

// Description:

// Demonstrates how to assign a font fallback rule for a specific Unicode range

// (Cyrillic) to a presentation and then save the modified file using Aspose.Slides

// for .NET. The example loads an existing PPTX, configures the FontsManager with

// fallback rules, and writes the result to a new file.

//

// Keywords:

// C#, Aspose.Slides, PowerPoint, PPTX, FontFallback, FontFallBackRule, 

// FontFallBackRulesCollection, Presentation Processing, Office Automation

//

// Use Cases:

// - Ensure proper font rendering for characters not available in the original font.

// - Automate font fallback configuration in batch PowerPoint processing.

// - Build .NET tools that modify and re‑save presentations with custom font handling.

// - Validate and render presentations with multilingual content.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        string dataDir = "Data";

        string inputPath = Path.Combine(dataDir, "input.pptx");

        string outputPath = Path.Combine(dataDir, "output.pptx");



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        try

        {

            using (Presentation presentation = new Presentation(inputPath))

            {

                // Prepare fallback rules collection

                FontFallBackRulesCollection fallbackRules = new FontFallBackRulesCollection();

                // Example rule: Unicode range for Cyrillic (0x0400-0x04FF) fallback to Arial

                fallbackRules.Add(new FontFallBackRule(0x0400, 0x04FF, "Arial"));

                // Assign the collection to the FontsManager

                presentation.FontsManager.FontFallBackRulesCollection = fallbackRules;



                // Save the presentation after assigning fallback rules

                presentation.Save(outputPath, SaveFormat.Pptx);

            }

        }

        catch (NotSupportedException)

        {

            // Format not supported

        }

        catch (Exception ex)

        {

            // Handle other exceptions (e.g., external URL errors)

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

