using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pdf";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                {
                    // Configure PDF options to include notes on handouts
                    Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
                    pdfOptions.SlidesLayoutOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions
                    {
                        NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull
                    };

                    // Save the presentation as PDF with the specified options
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
                }
            }
            // Handle unsupported format exceptions
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                Console.WriteLine("The file format is not supported (PPTX).");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                Console.WriteLine("The file format is not supported (PPT).");
            }
            // General exception handling
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}