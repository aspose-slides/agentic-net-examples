// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Define fallback font order and save using C#

//

// Description:

// Demonstrates how to define custom font fallback rules for specific Unicode

// ranges and save the resulting presentation using Aspose.Slides for .NET.

// The example creates a new presentation, configures FontFallBackRulesCollection

// via the FontsManager, and writes the file to disk as a PPTX.

// This pattern helps developers ensure correct font substitution when

// processing multilingual PowerPoint content.

//

// Keywords:

// C#, Aspose.Slides, PowerPoint, PPTX, FontFallback, FontFallBackRule, 

// FontFallBackRulesCollection, FontsManager, Presentation, Unicode Range

//

// Use Cases:

// - Define fallback fonts for specific Unicode blocks in a presentation.

// - Build .NET utilities that enforce font substitution policies.

// - Generate or modify PPTX files with custom font fallback settings.

// - Validate multilingual presentations before distribution.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace FontFallbackExample

{

    class Program

    {

        static void Main(string[] args)

        {

            try

            {

                var outputPath = "FontFallbackPresentation.pptx";



                // Create a new presentation

                var presentation = new Presentation();



                // Initialize a new FontFallBackRulesCollection

                var rules = new FontFallBackRulesCollection();



                // Add fallback rule: Unicode range 0x0400-0x04FF uses "Arial"

                rules.Add(new FontFallBackRule(0x0400, 0x04FF, "Arial"));



                // Add fallback rule: Unicode range 0x0500-0x05FF uses "Times New Roman"

                rules.Add(new FontFallBackRule(0x0500, 0x05FF, "Times New Roman"));



                // Assign the rules collection to the presentation's FontsManager

                presentation.FontsManager.FontFallBackRulesCollection = rules;



                // Save the presentation

                presentation.Save(outputPath, SaveFormat.Pptx);

            }

            catch (Exception ex)

            {

                // Handle exceptions (e.g., unsupported format)

                Console.WriteLine("An error occurred: " + ex.Message);

                // Format not supported

            }

        }

    }

}

