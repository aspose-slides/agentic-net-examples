// -----------------------------------------------------------------------------
// Example: Resize slides and export to PDF using C#
//
// Description:
// Demonstrates how to resize all slides in a PowerPoint presentation to a
// custom size and export the result to a PDF file using Aspose.Slides for .NET.
// The example loads a PPTX file, applies a new slide dimension while ensuring
// existing content scales to fit, and saves the transformed presentation as PDF.
// This pattern is useful for automating slide‑size adjustments and PDF generation
// in .NET applications.
//
// Keywords:
// C#, Aspose.Slides for .NET, PowerPoint, PPTX, PDF, Resize Slides, Export,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate slide size standardization before publishing.
// - Convert resized PowerPoint decks to PDF for distribution.
// - Integrate slide resizing and PDF export into CI/CD pipelines.
// - Build command‑line tools for batch processing of presentations.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides.Export;

namespace SlideResizeAndExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pdf";

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

                // Set custom slide size (e.g., 800x600 points) and ensure content fits
                presentation.SlideSize.SetSize(800f, 600f, Aspose.Slides.SlideSizeScaleType.EnsureFit);

                // Export the modified presentation to PDF
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Handle the case where the requested format cannot be saved
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., file access issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
