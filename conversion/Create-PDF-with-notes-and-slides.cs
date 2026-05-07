using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output PDF path
            string outputPath = "output.pdf";

            // Check if the input file exists
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
                    // Configure PDF options to include both slides and speaker notes
                    PdfOptions pdfOptions = new PdfOptions();
                    pdfOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
                    {
                        NotesPosition = NotesPositions.BottomFull
                    };

                    // Save the presentation as PDF with the specified layout options
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
                }

                Console.WriteLine("PDF created successfully: " + outputPath);
            }
            catch (PptxUnsupportedFormatException)
            {
                // Handle unsupported file format
                Console.WriteLine("The provided file format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., I/O errors, Aspose.Slides internal errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}