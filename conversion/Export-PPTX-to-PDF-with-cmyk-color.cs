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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Configure PDF export options
            Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();

            // Set CMYK color space for professional printing if supported
            // Note: Aspose.Slides does not expose a direct CMYK option; this line is illustrative.
            // pdfOptions.ColorMode = Aspose.Slides.Export.ColorMode.Cmyk;

            // Save the presentation as PDF with the configured options
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

            // Dispose the presentation object
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            // Handle other exceptions
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}