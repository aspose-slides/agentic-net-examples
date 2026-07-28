// -----------------------------------------------------------------------------
// Example: Export presentation to PDF/A archival using C#
//
// Description:
// Demonstrates how to export a PowerPoint presentation to a PDF/A-2a archival
// PDF file using C# and Aspose.Slides for .NET. The example loads a PPTX file,
// configures PDF options for PDF/A compliance, and saves the result as a PDF.
// This pattern can be used in console applications to automate PPTX to PDF/A
// conversion for archiving or compliance purposes.
//
// Keywords:
// C#, Aspose.Slides, PDF/A, PDF, PowerPoint, PPTX, Export, Presentation, 
// Archival, .NET, Office Automation
//
// Use Cases:
// - Convert PowerPoint files to PDF/A-2a for long‑term archival.
// - Build C# utilities for automated presentation compliance.
// - Integrate PDF/A export into .NET workflows or CI pipelines.
// - Validate and process PPTX files before publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides.Export;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                // Load the presentation
                presentation = new Aspose.Slides.Presentation(inputPath);

                // Set PDF options with PDF/A compliance
                Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
                pdfOptions.Compliance = Aspose.Slides.Export.PdfCompliance.PdfA2a;

                // Save as PDF
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // TODO: handle unsupported format
            }
            finally
            {
                // Ensure the presentation is saved and resources are released
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}
