using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input PPT file path and output PDF file path
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
            // Load the PPT file into a byte array
            byte[] pptBytes = File.ReadAllBytes(inputPath);

            // Create a memory stream from the byte array
            using (MemoryStream memoryStream = new MemoryStream(pptBytes))
            {
                // Load the presentation from the memory stream
                using (Presentation presentation = new Presentation(memoryStream))
                {
                    // Configure PDF options for PDF/A‑1b compliance
                    PdfOptions pdfOptions = new PdfOptions();
                    pdfOptions.Compliance = Aspose.Slides.Export.PdfCompliance.PdfA1b;

                    // Save the presentation as a PDF file
                    presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);
                }
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}