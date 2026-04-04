using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPresentationToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pdf";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Access document properties
                    IDocumentProperties docProps = presentation.DocumentProperties;

                    // Preserve animation timing information in a custom property
                    // (Here we store a placeholder string; replace with actual timing data as needed)
                    docProps.SetCustomPropertyValue("AnimationTiming", "Preserved");

                    // Configure PDF options (if needed, customize further)
                    PdfOptions pdfOptions = new PdfOptions();

                    // Save the presentation as PDF
                    presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);
                }

                Console.WriteLine($"Presentation converted to PDF successfully: {outputPath}");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported for conversion.
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., network errors for external URLs)
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}