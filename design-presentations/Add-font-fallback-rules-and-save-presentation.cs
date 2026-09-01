// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Add font fallback rules and save presentation using C#

//

// Description:

// Demonstrates how to add font fallback rules for specific Unicode ranges 

// (Cyrillic and Emoji) and save the resulting presentation using C# and 

// Aspose.Slides for .NET. The example shows the required presentation-processing 

// steps for PowerPoint files and produces the output in a standalone console 

// application. Developers can use this pattern to automate PPTX workflows, 

// validate results, or integrate presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Font Fallback, Unicode Ranges, 

// Presentation Saving, Office Automation

//

// Use Cases:

// - Automate adding font fallback rules for specific Unicode blocks and save 

//   presentations.

// - Build C# tools for PowerPoint presentation processing with custom font 

//   handling.

// - Generate or transform PPTX files in .NET applications with fallback fonts.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------



using System;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace FontFallbackDemo

{

    class Program

    {

        static void Main(string[] args)

        {

            // Create a new presentation

            Presentation presentation = new Presentation();



            // Initialize a new FontFallBackRulesCollection

            IFontFallBackRulesCollection rules = new FontFallBackRulesCollection();



            // Add a rule for Unicode range 0x400-0x4FF with a single fallback font

            rules.Add(new FontFallBackRule(0x400u, 0x4FFu, "Times New Roman"));



            // Add a rule for Unicode range 0x1F600-0x1F64F with multiple fallback fonts

            string[] emojiFonts = new string[] { "Segoe UI Emoji", "Arial Unicode MS" };

            rules.Add(new FontFallBackRule(0x1F600u, 0x1F64Fu, emojiFonts));



            // Assign the collection to the presentation's FontsManager

            presentation.FontsManager.FontFallBackRulesCollection = rules;



            // Save the presentation

            presentation.Save("FontFallbackOutput.pptx", SaveFormat.Pptx);



            // Dispose the presentation

            presentation.Dispose();

        }

    }

}

