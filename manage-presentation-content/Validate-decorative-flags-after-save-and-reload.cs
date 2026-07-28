// -----------------------------------------------------------------------------
// Example: Validate decorative flags after save and reload using C#
//
// Description:
// Demonstrates how to set the ReadOnlyRecommended decorative flag on a
// presentation, save the file, reload it, and verify that the flag persists
// using Aspose.Slides for .NET. This example shows the required steps for
// presentation processing and validation in a standalone console application.
// Developers can use this pattern to automate PPTX workflows, validate results,
// or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Validate, Decorative, Flags,
// After, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate validation of decorative flags after saving and reloading a PPTX.
// - Build C# tools for PowerPoint presentation processing and integrity checks.
// - Generate or transform PPTX files in .NET applications while preserving settings.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

        // Create or load a presentation
        Presentation presentation;
        if (File.Exists(inputPath))
        {
            try
            {
                presentation = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }
        }
        else
        {
            presentation = new Presentation();
        }

        // Set a decorative flag (read‑only recommendation)
        presentation.ProtectionManager.ReadOnlyRecommended = true;

        // Save the presentation
        try
        {
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle save errors (e.g., unsupported format)
            Console.WriteLine("Failed to save presentation: " + ex.Message);
            presentation.Dispose();
            return;
        }
        presentation.Dispose();

        // Reload the saved presentation and verify the flag persists
        try
        {
            Presentation reloaded = new Presentation(outputPath);
            bool flagPersisted = reloaded.ProtectionManager.ReadOnlyRecommended;
            Console.WriteLine("ReadOnlyRecommended flag persisted: " + flagPersisted);
            reloaded.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to reload presentation: " + ex.Message);
        }
    }
}
