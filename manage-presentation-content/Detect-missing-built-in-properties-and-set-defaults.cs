// -----------------------------------------------------------------------------
// Example: Detect missing built in properties and set defaults using C#
//
// Description:
// Demonstrates how to detect missing built‑in document properties in a PowerPoint
// presentation and set them to default values using C# and Aspose.Slides for .NET.
// The example creates a new presentation when the input file is absent, clears
// any existing built‑in properties, and saves the result. When an existing file
// is present, it loads the presentation, clears built‑in properties, and saves
// the updated file. This pattern helps ensure presentations contain a consistent
// set of built‑in metadata.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Detect, Missing, Built,
// Properties, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate detection of missing built‑in properties and apply defaults.
// - Build C# tools for PowerPoint presentation metadata management.
// - Generate or transform PPTX files with consistent document properties.
// - Validate and normalize presentation metadata before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            // Create a new presentation if the input file does not exist
            using (var presentation = new Aspose.Slides.Presentation())
            {
                // Populate built‑in properties with default values
                presentation.DocumentProperties.ClearBuiltInProperties();

                // Save the presentation before exiting
                presentation.Save(outputPath, SaveFormat.Pptx);
                return;
            }
        }

        try
        {
            // Load the existing presentation
            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Populate built‑in properties with default values
                presentation.DocumentProperties.ClearBuiltInProperties();

                // Save the updated presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException ex)
        {
            // Format not supported (PPTX)
            Console.WriteLine("PPTX format not supported: " + ex.Message);
        }
        catch (Aspose.Slides.PptUnsupportedFormatException ex)
        {
            // Format not supported (PPT)
            Console.WriteLine("PPT format not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
