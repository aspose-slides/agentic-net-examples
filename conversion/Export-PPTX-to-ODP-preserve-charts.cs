// -----------------------------------------------------------------------------
// Example: Export PPTX to ODP preserving charts using C#
//
// Description:
// Demonstrates how to export a PPTX file to ODP while preserving chart objects
// using C# and Aspose.Slides for .NET. The example loads a PowerPoint presentation,
// configures ODP save options to keep charts intact, and saves the result as an
// OpenDocument Presentation file. This pattern can be used in console utilities,
// automated workflows, or any .NET application that needs to retain chart fidelity
// during format conversion.
//
// Keywords:
// C#, PowerPoint, PPTX, ODP, Aspose.Slides for .NET, Export, Preserve Charts, 
// Presentation Conversion, Office Automation
//
// Use Cases:
// - Convert PPTX to ODP without losing chart data.
// - Build C# tools that maintain visual integrity of presentations during export.
// - Integrate chart‑preserving conversion into .NET services or batch processes.
// - Validate and automate presentation workflows that involve ODP output.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportPptxToOdp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPTX file path
            string inputPath = "input.pptx";
            // Output ODP file path
            string outputPath = "output.odp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Configure ODP save options to preserve charts
                    OdpSaveOptions saveOptions = new OdpSaveOptions
                    {
                        PreserveCharts = true
                    };

                    // Save as ODP format with the specified options
                    presentation.Save(outputPath, saveOptions);
                }

                Console.WriteLine("Presentation successfully exported to ODP with charts preserved.");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The requested format is not supported by Aspose.Slides.
                Console.WriteLine("The ODP format is not supported for this operation.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
