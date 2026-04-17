using System;
using System.IO;
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
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Create PDF export options
            Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();

            // Optionally, convert metafiles to PNG to ensure static rendering
            pdfOptions.SaveMetafilesAsPng = true;

            // Save the presentation as PDF with the specified options
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

            // Ensure the presentation is saved before exiting
            pres.Dispose();

            Console.WriteLine("Presentation successfully exported to PDF: " + outputPath);
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The specified format is not supported for conversion.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}