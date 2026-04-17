using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

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
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Determine slide resolution based on slide size (using the first slide as reference)
            Aspose.Slides.ISlideSize slideSize = pres.SlideSize;
            float width = slideSize.Size.Width;
            float height = slideSize.Size.Height;

            // Example threshold: area greater than 800x600 considered high resolution
            bool isHighResolution = (width * height) > (800f * 600f);

            // Configure PDF options with appropriate JPEG quality
            Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
            if (isHighResolution)
            {
                pdfOptions.JpegQuality = 85; // High‑resolution slides
            }
            else
            {
                pdfOptions.JpegQuality = 60; // Low‑resolution slides
            }

            // Save the presentation as PDF with the specified options
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

            // Dispose the presentation
            pres.Dispose();
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