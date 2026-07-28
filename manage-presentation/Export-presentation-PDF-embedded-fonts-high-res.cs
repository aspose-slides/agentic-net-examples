// -----------------------------------------------------------------------------
// Example: Export presentation PDF embedded fonts high res using C#
//
// Description:
// Demonstrates how to export a PowerPoint presentation to a PDF file with
// embedded fonts and high‑resolution images using Aspose.Slides for .NET.
// The example loads a PPTX file, configures PDF export options for full font
// embedding and 300 dpi image resolution, and saves the result as a PDF.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Export, Presentation,
// Embedded Fonts, High Resolution, SufficientResolution, Office Automation
//
// Use Cases:
// - Convert PPTX files to PDF while preserving original fonts.
// - Generate high‑quality PDF documents from presentations for printing.
// - Automate batch conversion of presentations to PDF with custom export settings.
// - Integrate PDF export functionality into .NET applications or services.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportPresentationToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pdf";

            // Check if the input file exists
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
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported for loading.");
                return;
            }
            catch (Exception ex)
            {
                // Other loading errors
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            // Configure PDF export options
            Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
            pdfOptions.EmbedFullFonts = true;               // Embed all fonts
            pdfOptions.SufficientResolution = 300;          // High resolution images
            pdfOptions.BestImagesCompressionRatio = true;   // Optional: best compression

            try
            {
                // Save the presentation as PDF with the specified options
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
            }
            catch (Exception ex)
            {
                // Handle any errors during saving
                Console.WriteLine("Error saving PDF: " + ex.Message);
            }
            finally
            {
                // Ensure the presentation is disposed
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }

            Console.WriteLine("Export completed.");
        }
    }
}
