// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Set PPTX font fallback list using C#

//

// Description:

// Demonstrates how to define and apply a font fallback rule collection to a

// PowerPoint presentation using Aspose.Slides for .NET. The example creates a

// fallback rule for a specific Unicode range, adds alternative fonts, assigns

// the rule collection to the presentation's FontsManager, and saves the

// modified file. This pattern can be used in console applications or other

// .NET tools that need to ensure proper font rendering for characters not

// covered by the primary font.

//

// Keywords:

// C#, Aspose.Slides, PowerPoint, PPTX, Font fallback, Unicode range, Font

// management, Presentation processing, .NET automation

//

// Use Cases:

// - Ensure correct display of characters from specific Unicode blocks in PPTX

//   files.

// - Automate font fallback configuration for batch processing of presentations.

// - Integrate font fallback handling into custom PowerPoint generation tools.

// - Validate and adjust font settings before publishing presentations.

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



        Aspose.Slides.Presentation pres = null;

        try

        {

            if (File.Exists(inputPath))

            {

                pres = new Aspose.Slides.Presentation(inputPath);

            }

            else

            {

                pres = new Aspose.Slides.Presentation();

            }



            // Define a fallback rule for a Unicode range with primary font "Arial"

            Aspose.Slides.IFontFallBackRule fallbackRule = new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Arial");

            // Add two alternative fallback fonts

            fallbackRule.AddFallBackFonts("Calibri");

            fallbackRule.AddFallBackFonts("Times New Roman");



            // Create a collection and add the rule

            Aspose.Slides.IFontFallBackRulesCollection rulesCollection = new Aspose.Slides.FontFallBackRulesCollection();

            rulesCollection.Add(fallbackRule);



            // Apply the fallback rules to the presentation

            pres.FontsManager.FontFallBackRulesCollection = rulesCollection;



            // Save the presentation

            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        }

        catch (Exception ex)

        {

            // Handle exceptions (e.g., unsupported format, file access issues)

        }

        finally

        {

            if (pres != null)

            {

                pres.Dispose();

            }

        }

    }

}

