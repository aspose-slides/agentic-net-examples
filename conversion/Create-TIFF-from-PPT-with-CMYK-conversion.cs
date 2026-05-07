using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.tiff";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.Export.TiffOptions options = new Aspose.Slides.Export.TiffOptions();
            options.CompressionType = Aspose.Slides.Export.TiffCompressionTypes.LZW;
            options.DpiX = 300;
            options.DpiY = 300;
            // Set pixel format to 24bpp RGB (closest to CMYK for print-ready output)
            options.PixelFormat = Aspose.Slides.Export.ImagePixelFormat.Format24bppRgb;
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, options);
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