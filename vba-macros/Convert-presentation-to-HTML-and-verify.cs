// -----------------------------------------------------------------------------
// Example: Convert presentation to HTML and verify using C#
//
// Description:
// Demonstrates how to load a PPTM file, remove embedded binary objects (including
// VBA macros), verify that no VBA code remains, and convert the presentation to
// HTML using Aspose.Slides for .NET. The example is a self‑contained console
// application suitable for automating PowerPoint processing workflows.
//
// Keywords:
// C#, PowerPoint, PPTM, Aspose.Slides for .NET, HTML, Convert, Presentation,
// VBA, Remove VBA, Verify, Presentation Processing, Office Automation
//
// Use Cases:
// - Remove VBA macros from PPTM files before publishing.
// - Convert PowerPoint presentations to HTML for web display.
// - Validate that presentations are free of embedded code.
// - Build .NET tools for automated PowerPoint content transformation.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptm");
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load presentation while removing embedded binary objects (including VBA)
            LoadOptions loadOptions = new LoadOptions();
            loadOptions.DeleteEmbeddedBinaryObjects = true;

            using (Presentation presentation = new Presentation(inputPath, loadOptions))
            {
                // Verify that no VBA code is present
                if (presentation.VbaProject != null && presentation.VbaProject.Modules.Count > 0)
                {
                    Console.WriteLine("VBA code still present after loading.");
                }
                else
                {
                    Console.WriteLine("No VBA code detected.");
                }

                // Convert to HTML
                presentation.Save(outputPath, SaveFormat.Html);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
