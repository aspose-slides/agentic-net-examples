using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
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
                // Set custom slide size to Letter (8.5 x 11 inches)
                presentation.SlideSize.SetSize(612f, 792f, SlideSizeScaleType.EnsureFit);

                // Configure PDF options to include hidden slides
                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.ShowHiddenSlides = true;

                // Save the presentation as PDF
                presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);
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