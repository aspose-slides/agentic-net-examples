using System;
using System.IO;
using Aspose.Slides.Export;

namespace SlideToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
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
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Set slide size to Letter format (8.5 x 11 inches) with EnsureFit scaling
                    presentation.SlideSize.SetSize(612f, 792f, Aspose.Slides.SlideSizeScaleType.EnsureFit);

                    // Configure PDF options to include hidden slides
                    Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
                    pdfOptions.ShowHiddenSlides = true;

                    // Save the presentation as PDF
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}