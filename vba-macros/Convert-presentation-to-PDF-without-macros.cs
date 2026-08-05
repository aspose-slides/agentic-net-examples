// -----------------------------------------------------------------------------
// Example: Convert presentation to PDF without macros using C#
//
// Description:
// Demonstrates how to convert a macro‑enabled PowerPoint presentation (PPTM) to
// PDF while removing all embedded macros and binary objects using Aspose.Slides for
// .NET. The example loads the presentation with DeleteEmbeddedBinaryObjects set to
// true, then saves it as PDF. This pattern can be used to automate PPTM workflows,
// ensure macro‑free PDFs, or integrate presentation processing into .NET
// applications.
//
// Keywords:
// C#, PowerPoint, PPTM, Aspose.Slides for .NET, PDF, Convert, Presentation,
// Without, Macros, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate conversion of macro‑enabled presentations to macro‑free PDFs.
// - Build C# tools for secure PowerPoint document handling.
// - Generate PDF outputs from PPTM files in .NET applications.
// - Remove macros before publishing or sharing presentation content.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input macro‑enabled presentation path
        string inputPath = "macro_enabled.pptm";
        // Output PDF path
        string outputPath = "output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load presentation without embedded binary objects (macros, OLE, etc.)
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
            loadOptions.DeleteEmbeddedBinaryObjects = true;

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath, loadOptions))
            {
                // Save as PDF; macros are omitted due to load options
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
