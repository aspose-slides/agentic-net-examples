using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        var inputPath = "input.pptx";
        var outputPath = "output.pdf";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            var presentation = new Aspose.Slides.Presentation(inputPath);

            // Configure PDF options to embed all fonts
            var pdfOptions = new Aspose.Slides.Export.PdfOptions();
            pdfOptions.EmbedFullFonts = true; // Preserve embedded fonts

            // Save the presentation as PDF
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
            presentation.Dispose();

            Console.WriteLine("Presentation exported to PDF successfully.");
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}