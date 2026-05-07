using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        var inputPath = "input.pptx";
        var outputPath = "output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load presentation
            var presentation = new Presentation(inputPath);

            // Set PDF options with PDF/A‑1b compliance
            var pdfOptions = new PdfOptions();
            pdfOptions.Compliance = PdfCompliance.PdfA1b;

            // Save selected slides (1, 4, 9) as PDF
            presentation.Save(outputPath, new int[] { 1, 4, 9 }, SaveFormat.Pdf, pdfOptions);

            // Dispose presentation
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            // Comment: format not supported
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., I/O errors)
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}