// -----------------------------------------------------------------------------
// Example: Export presentation to XPS high quality using C#
//
// Description:
// Demonstrates how to export a PowerPoint presentation to a high‑quality XPS
// document using C# and Aspose.Slides for .NET. The example loads a PPTX file,
// configures XPS export options to improve rendering of metafiles, and saves the
// result as an XPS file. This pattern can be used in console applications or
// automated workflows that require high‑fidelity XPS output.
//
// Keywords:
// C#, Aspose.Slides, XPS, High Quality, Export, Presentation, PowerPoint, PPTX,
// Office Automation, .NET
//
// Use Cases:
// - Convert PPTX presentations to high‑quality XPS for printing or archiving.
// - Build command‑line tools for batch conversion of PowerPoint files to XPS.
// - Integrate XPS export into .NET applications that process presentation content.
// - Ensure metafile graphics are rendered as PNG for better visual fidelity.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportToXps
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = "output.xps";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Configure high‑quality XPS options for printing
                Aspose.Slides.Export.XpsOptions xpsOptions = new Aspose.Slides.Export.XpsOptions();
                xpsOptions.SaveMetafilesAsPng = true; // Convert metafiles to PNG for better quality

                // Save the presentation to XPS format with the specified options
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Xps, xpsOptions);

                // Dispose the presentation before exiting
                presentation.Dispose();

                Console.WriteLine("Presentation successfully exported to XPS: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors, licensing issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
