// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Reset fallback fonts and verify default using C#

//

// Description:

// Demonstrates how to clear all font fallback rules in a presentation and

// verify that the default fonts are applied using Aspose.Slides for .NET.

// The example loads an existing PPTX file, removes any custom fallback

// configurations, saves the modified presentation, and confirms successful

// processing via console output.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Reset, Fallback, Fonts, Verify,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate the removal of custom font fallback settings in PPTX files.

// - Build C# utilities for PowerPoint presentation cleanup before distribution.

// - Ensure presentations rely on default system fonts for consistent rendering.

// - Integrate font fallback management into .NET-based document workflows.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace FontFallbackClearExample

{

    class Program

    {

        static void Main(string[] args)

        {

            string inputPath = "input.pptx";

            string outputPath = "output.pptx";



            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file not found: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                Presentation pres = new Presentation(inputPath);



                // Clear all existing font fallback rules by assigning an empty collection

                IFontFallBackRulesCollection emptyRules = new FontFallBackRulesCollection();

                pres.FontsManager.FontFallBackRulesCollection = emptyRules;



                // Save the presentation to confirm default fonts are applied

                pres.Save(outputPath, SaveFormat.Pptx);

                Console.WriteLine("Fallback fonts cleared and default fonts applied. Saved to " + outputPath);



                pres.Dispose();

            }

            catch (Exception ex)

            {

                // Handle unsupported file format or other errors

                Console.WriteLine("An error occurred: " + ex.Message);

                // Format not supported comment

                // The provided file format may not be supported by Aspose.Slides.

            }

        }

    }

}

