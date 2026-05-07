using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input PPT file path
        string inputFile = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        // Output directory and PDF file path
        string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
        string outputFile = Path.Combine(outputDir, "output.pdf");
        // Password for the PDF
        string pdfPassword = "pdfPassword";

        // Verify that the input file exists
        if (!File.Exists(inputFile))
        {
            Console.WriteLine("Input file does not exist: " + inputFile);
            return;
        }

        // Ensure the output directory exists
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        try
        {
            // Load the presentation
            Presentation presentation = new Presentation(inputFile);

            // Configure PDF options: set password and PDF/A-1b compliance
            PdfOptions pdfOptions = new PdfOptions();
            pdfOptions.Password = pdfPassword;
            pdfOptions.Compliance = PdfCompliance.PdfA1b;

            // Save the presentation as a password‑protected PDF/A‑1b file
            presentation.Save(outputFile, SaveFormat.Pdf, pdfOptions);

            // Dispose the presentation object
            presentation.Dispose();

            Console.WriteLine("Presentation successfully converted to PDF/A‑1b with password protection.");
        }
        catch (NotSupportedException)
        {
            // Handle unsupported file format
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., I/O errors, web service issues)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}