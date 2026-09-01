// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Render presentation to PDF with fallback fonts using C#

//

// Description:

// Demonstrates how to render a PowerPoint presentation (PPTX) to PDF while

// applying fallback font rules using Aspose.Slides for .NET. The example loads

// an input PPTX file, configures a fallback rule for a specific Unicode range

// (e.g., emojis) to use the "Segoe UI Emoji" font, and saves the result as a PDF.

// This pattern is useful for ensuring proper rendering of characters that may

// be missing from the primary fonts in the presentation.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Render, Presentation,

// Fallback, Fonts, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate rendering of presentations to PDF with fallback fonts.

// - Build C# tools for PowerPoint presentation processing that require

//   reliable character rendering.

// - Generate or transform PPTX files in .NET applications while handling

//   missing glyphs.

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

        // Input and output file paths

        string inputPath = "input.pptx";

        string outputPath = "output.pdf";



        // Check if the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load the presentation

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



            // Create a collection of fallback font rules

            Aspose.Slides.IFontFallBackRulesCollection rules = new Aspose.Slides.FontFallBackRulesCollection();



            // Add a fallback rule (example: Unicode range for emojis to "Segoe UI Emoji")

            rules.Add(new Aspose.Slides.FontFallBackRule(0x1F600, 0x1F64F, "Segoe UI Emoji"));



            // Assign the fallback rules collection to the presentation's FontsManager

            presentation.FontsManager.FontFallBackRulesCollection = rules;



            // Save the presentation as PDF

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);



            // Dispose the presentation

            presentation.Dispose();

        }

        catch (Exception ex)

        {

            // Handle unsupported format or other errors

            // format not supported

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

