// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Implement fallback font for default regular using C#

//

// Description:

// Demonstrates how to set a fallback font for the default regular font when

// loading a PowerPoint presentation using Aspose.Slides for .NET. The example

// loads a PPTX file with a specified secondary font, optionally defines a

// universal font fallback rule, and saves the modified presentation.

// This pattern helps ensure text is rendered correctly when the original

// regular font is missing.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Implement, Fallback, Font,

// Default, Presentation Processing, Office Automation

//

// Use Cases:

// - Apply a fallback font for presentations lacking the original regular font.

// - Build .NET tools that robustly handle missing fonts in PPTX files.

// - Automate PPTX processing with reliable font substitution.

// - Validate and transform presentations before distribution.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Input and output file paths

        string inputPath = "input.pptx";

        string outputPath = "output.pptx";

        // Secondary font to use when the default regular font is unavailable

        string secondaryFont = "Arial";



        // Check if the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load options with a fallback regular font

            LoadOptions loadOptions = new LoadOptions();

            loadOptions.DefaultRegularFont = secondaryFont;



            // Load the presentation using the load options

            Presentation pres = new Presentation(inputPath, loadOptions);



            // Optional: define a font fallback rule for all Unicode ranges

            IFontFallBackRulesCollection rules = new FontFallBackRulesCollection();

            IFontFallBackRule rule = new FontFallBackRule(0x0, 0xFFFF, secondaryFont);

            rules.Add(rule);

            pres.FontsManager.FontFallBackRulesCollection = rules;



            // Save the presentation

            pres.Save(outputPath, SaveFormat.Pptx);

            pres.Dispose();

        }

        catch (Exception ex)

        {

            // Handle unsupported format or other errors

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

