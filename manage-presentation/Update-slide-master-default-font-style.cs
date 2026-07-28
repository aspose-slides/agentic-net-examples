// -----------------------------------------------------------------------------
// Example: Update slide master default font style using C#
//
// Description:
// Demonstrates how to replace a source font with a destination font across a
// presentation, affecting the slide master default font style, using C# and
// Aspose.Slides for .NET. The example shows the required presentation-processing
// steps for PowerPoint files and produces the requested output in a standalone
// console application. Developers can use this pattern to automate PPTX workflows,
// validate results, or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Update, Slide, Master, Default,
// Font, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate updating slide master default font style.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
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
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Define the source font to replace and the destination font
            IFontData sourceFont = new FontData("Calibri");
            IFontData destFont = new FontData("Arial");

            // Replace the source font with the destination font across the presentation
            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            // Save the updated presentation
            pres.Save(outputPath, SaveFormat.Pptx);

            // Clean up resources
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported file format
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
