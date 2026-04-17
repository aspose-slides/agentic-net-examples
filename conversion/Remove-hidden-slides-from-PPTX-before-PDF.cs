using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveHiddenSlidesAndConvertToPdf
{
    class Program
    {
        static void Main()
        {
            // Input and output file paths
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
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Configure PDF options to exclude hidden slides
                    Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
                    pdfOptions.ShowHiddenSlides = false; // Ensure hidden slides are not included

                    // Save the presentation as PDF
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
                }

                Console.WriteLine("PDF saved successfully to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // The file format is not supported for conversion
                Console.WriteLine("The provided file format is not supported for PDF conversion.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}