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