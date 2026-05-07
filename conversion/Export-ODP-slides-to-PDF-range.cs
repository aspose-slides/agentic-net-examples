using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportSelectedSlides
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input ODP file path
            string inputPath = "input.odp";
            // Output PDF file path
            string outputPath = "selected_slides.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the ODP presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Define slide indices to export (2 through 5). Indices are 1‑based.
                    int[] slideIndices = new int[] { 2, 3, 4, 5 };

                    // Save the selected slides as PDF
                    presentation.Save(outputPath, slideIndices, SaveFormat.Pdf);
                }

                Console.WriteLine("Selected slides exported successfully to: " + outputPath);
            }
            catch (InvalidOperationException)
            {
                // Format not supported for the requested operation
                Console.WriteLine("The specified format is not supported for exporting selected slides.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., I/O errors, permission issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}