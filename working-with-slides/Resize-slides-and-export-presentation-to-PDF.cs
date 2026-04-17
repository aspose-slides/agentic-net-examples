using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideResizeAndExport
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPdfPath = "output.pdf";
            string outputPptxPath = "output_resized.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                Presentation presentation = new Presentation(inputPath);
                // Resize slides to custom dimensions (e.g., 800x600 points) and ensure content fits
                presentation.SlideSize.SetSize(800f, 600f, SlideSizeScaleType.EnsureFit);
                // Export the modified presentation to PDF
                presentation.Save(outputPdfPath, SaveFormat.Pdf);
                // Save the resized presentation as PPTX before exiting
                presentation.Save(outputPptxPath, SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}