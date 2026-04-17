using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output paths
        string inputFileName = "protected.pptx";
        string outputFileName = "output.pdf";
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), inputFileName);
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), outputFileName);
        string password = "myPassword";

        // Check if input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Open password‑protected presentation
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
            loadOptions.Password = password;
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath, loadOptions);

            // Set PDF options (no encryption for output)
            Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
            pdfOptions.Password = string.Empty; // ensure PDF is not password protected

            // Convert to PDF
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
            presentation.Dispose();

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The provided file format is not supported.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}