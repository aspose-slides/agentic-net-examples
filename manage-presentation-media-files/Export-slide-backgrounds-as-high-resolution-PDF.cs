// -----------------------------------------------------------------------------
// Example: Export slide backgrounds as high resolution PDF using C#
//
// Description:
// Demonstrates how to export the backgrounds of all slides in a PowerPoint
// presentation to a high‑resolution PDF file using C# and Aspose.Slides for .NET.
// The example loads a PPTX file, configures PDF export options for 300 DPI
// printing quality, and saves the result as a PDF document.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Export, Slide, Backgrounds,
// High Resolution, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate the conversion of slide backgrounds to high‑resolution PDFs.
// - Build .NET tools for extracting and preserving slide visual assets.
// - Generate printable PDFs from presentations with optimal quality.
// - Integrate slide background export into larger PowerPoint processing pipelines.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pdf";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Configure PDF options for high‑resolution output
                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.SufficientResolution = 300f; // 300 DPI for printing quality

                // Save the presentation as a PDF
                presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);
            }
        }
        catch (NotSupportedException)
        {
            // Handle unsupported format exception
            Console.WriteLine("The file format is not supported for PDF conversion.");
        }
        catch (Exception ex)
        {
            // Handle any other exceptions
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
