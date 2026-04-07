using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace HandoutPdfGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "handout.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Configure PDF export options for handout layout with two columns
                    PdfOptions pdfOptions = new PdfOptions();
                    HandoutLayoutingOptions handoutOptions = new HandoutLayoutingOptions();
                    handoutOptions.Handout = HandoutType.Handouts2; // Two slides per page (two‑column)
                    // Note: HandoutLayoutingOptions automatically places speaker notes beneath each slide image
                    pdfOptions.SlidesLayoutOptions = handoutOptions;

                    // Save the handout PDF
                    presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);
                }

                Console.WriteLine("Handout PDF created successfully: " + outputPath);
            }
            // Handle unsupported file format exceptions
            catch (PptxUnsupportedFormatException)
            {
                Console.WriteLine("The source file format is not supported (PPTX).");
            }
            catch (PptUnsupportedFormatException)
            {
                Console.WriteLine("The source file format is not supported (PPT).");
            }
            // General exception handling
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}