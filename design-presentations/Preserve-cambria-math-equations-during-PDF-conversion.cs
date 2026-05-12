using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PreserveCambriaMath
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Set PDF options to preserve Cambria Math equations
                    PdfOptions pdfOptions = new PdfOptions();
                    pdfOptions.DefaultRegularFont = "Cambria Math";
                    pdfOptions.RasterizeUnsupportedFontStyles = false;

                    // Save the presentation as PDF
                    presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);
                }
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