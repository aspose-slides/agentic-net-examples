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

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Set PDF options with PDF/A‑1b compliance
            PdfOptions pdfOptions = new PdfOptions();
            pdfOptions.Compliance = PdfCompliance.PdfA1b;

            // Specify the slides to convert (1‑based indexing)
            int[] selectedSlides = new int[] { 1, 4, 9 };

            // Save the selected slides as a PDF with the specified options
            presentation.Save(outputPath, selectedSlides, SaveFormat.Pdf, pdfOptions);

            // Ensure the presentation is saved before exiting
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The specified format is not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}