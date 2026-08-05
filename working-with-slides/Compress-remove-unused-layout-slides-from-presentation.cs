// -----------------------------------------------------------------------------
// Example: Compress remove unused layout slides from presentation using C#
//
// Description:
// Demonstrates how to compress and remove unused layout slides from a PowerPoint
// presentation using C# and Aspose.Slides for .NET. The example loads an existing
// PPTX file, invokes the compression utility to eliminate layout slides that are
// not referenced by any slide, and saves the optimized presentation.
// This pattern can be used to reduce file size and improve performance of PPTX
// files in automated workflows.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Compress, Remove, Unused, Layout,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate removal of unused layout slides to shrink presentation size.
// - Build C# utilities for PowerPoint file optimization.
// - Integrate presentation cleanup steps into .NET applications or CI pipelines.
// - Prepare PPTX files for distribution by eliminating unnecessary resources.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file names
        string inputFileName = "input.pptx";
        string outputFileName = "output.pptx";

        // Build full paths
        string inputPath = Path.Combine(Environment.CurrentDirectory, inputFileName);
        string outputPath = Path.Combine(Environment.CurrentDirectory, outputFileName);

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Remove all unused layout slides
            Compress.RemoveUnusedLayoutSlides(presentation);

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
