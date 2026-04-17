using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input presentation path
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load presentation
            Presentation presentation = new Presentation(inputPath);

            // Configure TIFF options with LZW compression and high DPI
            TiffOptions tiffOptions = new TiffOptions();
            tiffOptions.CompressionType = TiffCompressionTypes.LZW;
            tiffOptions.DpiX = 300U;
            tiffOptions.DpiY = 300U;

            // Export each slide as a separate high‑resolution TIFF file
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                ISlide slide = presentation.Slides[i];
                using (IImage image = slide.GetImage(tiffOptions))
                {
                    string outputFile = Path.Combine(Directory.GetCurrentDirectory(), $"slide_{i + 1}.tiff");
                    image.Save(outputFile, Aspose.Slides.ImageFormat.Tiff);
                }
            }

            // Save the presentation before exiting (optional)
            string outputPresentationPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
            presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
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