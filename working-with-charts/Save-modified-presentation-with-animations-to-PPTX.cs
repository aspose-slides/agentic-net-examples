// -----------------------------------------------------------------------------
// Example: Save modified presentation with animations to PPTX using C#
//
// Description:
// Demonstrates how to load a PowerPoint presentation while preserving its
// animations and save it as a new PPTX file using Aspose.Slides for .NET.
// The example shows the required presentation‑processing steps for handling
// presentations with animations and produces the requested output in a
// standalone console application. Developers can use this pattern to automate
// PPTX workflows, validate results, or integrate presentation logic into .NET
// applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Save, Modified, Presentation,
// Animations, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate saving presentations with animations to PPTX.
// - Build C# tools for PowerPoint presentation processing that preserve animations.
// - Generate or transform PPTX files while retaining animation data in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation (animations are preserved)
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Save the presentation to a new PPTX file
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }

                Console.WriteLine("Presentation saved successfully to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported for saving.
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
