// -----------------------------------------------------------------------------
// Example: Set presentation view mode to read only using C#
//
// Description:
// Demonstrates how to set a PowerPoint presentation's view mode to read‑only
// by enabling the ReadOnlyRecommended flag using Aspose.Slides for .NET. The
// example creates a new presentation, configures it for read‑only recommendation,
// and saves the file as a PPTX. This pattern can be used in console utilities
// or automated workflows that need to protect presentations from editing.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Presentation, View Mode, Read‑Only,
// ReadOnlyRecommended, Presentation Protection, Office Automation
//
// Use Cases:
// - Generate read‑only PowerPoint files programmatically.
// - Protect presentations from accidental edits in automated pipelines.
// - Build .NET tools that enforce read‑only settings before distribution.
// - Integrate presentation protection into larger document processing systems.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define output folder and ensure it exists
        string outFolder = Path.Combine(Directory.GetCurrentDirectory(), "Output");
        if (!Directory.Exists(outFolder))
        {
            Directory.CreateDirectory(outFolder);
        }

        // Define output file path
        string outPath = Path.Combine(outFolder, "ReadOnlyPresentation.pptx");

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Set the presentation to read‑only (editing disabled)
        pres.ProtectionManager.ReadOnlyRecommended = true;

        // Save the presentation
        pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation object
        pres.Dispose();
    }
}
