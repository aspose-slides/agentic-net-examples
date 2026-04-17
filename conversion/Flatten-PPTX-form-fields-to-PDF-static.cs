using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPptxToPdf
{
    class Program
    {
        static void Main(string[] args)
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
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Configure PDF options to flatten form fields (include OLE data as static content)
                Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
                pdfOptions.IncludeOleData = true;

                // Save the presentation as PDF
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

                // Dispose the presentation object
                presentation.Dispose();

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (NotSupportedException ex)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}