// -----------------------------------------------------------------------------
// Example: Export presentation to ZIP64 with properties using C#
//
// Description:
// Demonstrates how to export a PowerPoint presentation to a ZIP64 package while
// preserving all document properties using C# and Aspose.Slides for .NET. The
// example loads an existing PPTX file, saves it with ZIP64 mode always enabled,
// and writes the result to a new file. This pattern can be used to ensure large
// presentations are saved in a format that supports files larger than 4 GB.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, ZIP64, Presentation,
// Properties, Office Automation
//
// Use Cases:
// - Automate export of presentations to ZIP64 format for large files.
// - Build C# utilities for PowerPoint presentation processing with property
//   preservation.
// - Integrate ZIP64 export functionality into .NET applications handling PPTX
//   files.
// - Ensure compatibility of large presentations with storage and sharing
//   platforms that require ZIP64.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportPresentationZip
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string outputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "output-zip64.pptx");

            // Verify that the input file exists
            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine("Input file does not exist: " + inputFilePath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputFilePath);

                // Save the presentation as a ZIP64 package while preserving all document properties
                presentation.Save(
                    outputFilePath,
                    Aspose.Slides.Export.SaveFormat.Pptx,
                    new Aspose.Slides.Export.PptxOptions()
                    {
                        Zip64Mode = Aspose.Slides.Export.Zip64Mode.Always
                    });

                // Dispose the presentation object
                presentation.Dispose();

                Console.WriteLine("Presentation exported successfully to: " + outputFilePath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported for this operation.
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
