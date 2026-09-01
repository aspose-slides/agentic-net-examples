// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Set Cyrillic fallback font collection using C#

//

// Description:

// Demonstrates how to configure a Cyrillic fallback font collection for a

// presentation using Aspose.Slides for .NET. The example creates a new

// presentation, defines fallback rules for the Cyrillic Unicode block, assigns

// them to the FontsManager, and saves the result as a PPTX file. This pattern

// can be used to ensure proper font rendering for Cyrillic text in automated

// PowerPoint workflows.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Cyrillic, Fallback, Font,

// Collection, Presentation Processing, Office Automation

//

// Use Cases:

// - Configure Cyrillic fallback fonts for generated presentations.

// - Build .NET tools that guarantee correct Cyrillic text rendering.

// - Automate PPTX creation or modification with custom font fallback rules.

// - Validate font fallback configurations before publishing presentations.

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

            // Create a new presentation

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();



            // Initialize a new fallback rules collection

            Aspose.Slides.IFontFallBackRulesCollection rules = new Aspose.Slides.FontFallBackRulesCollection();



            // Define Russian fonts for Cyrillic Unicode block (U+0400 to U+04FF)

            string[] russianFonts = new string[] { "Arial", "Times New Roman", "Calibri" };

            rules.Add(new Aspose.Slides.FontFallBackRule(0x0400, 0x04FF, russianFonts));



            // Assign the rules collection to the presentation's FontsManager

            presentation.FontsManager.FontFallBackRulesCollection = rules;



            // Save the presentation

            try

            {

                presentation.Save("CyrillicFallback.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            }

            catch (NotSupportedException)

            {

                // Format not supported

            }



            // Dispose the presentation

            presentation.Dispose();

        }

    }

}

