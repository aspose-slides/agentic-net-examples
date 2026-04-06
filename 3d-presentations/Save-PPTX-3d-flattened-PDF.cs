using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesPdfExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string outputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            // Check if the input file exists
            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine("Input file does not exist: " + inputFilePath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputFilePath);

                // Configure PDF options to flatten 3D objects into static images
                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.SaveMetafilesAsPng = true; // Rasterize metafiles (including 3D objects)
                pdfOptions.IncludeOleData = false;    // Do not include OLE data

                // Save the presentation as PDF
                presentation.Save(outputFilePath, SaveFormat.Pdf, pdfOptions);

                // Dispose the presentation
                presentation.Dispose();

                Console.WriteLine("Presentation successfully saved as PDF: " + outputFilePath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}