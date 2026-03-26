using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input PowerPoint file path
        string inputPath = "input.pptx";
        // Output PDF file path
        string outputPath = "output.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation from the file
        Presentation presentation = new Presentation(inputPath);

        // Create PDF export options (default options preserve layout)
        PdfOptions pdfOptions = new PdfOptions();

        // Save the presentation as PDF
        presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);

        // Release resources
        presentation.Dispose();

        Console.WriteLine("Presentation successfully exported to PDF.");
    }
}