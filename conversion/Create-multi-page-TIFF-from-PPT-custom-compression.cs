using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "input.pptx");
        string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output.tiff");

        if (!System.IO.File.Exists(inputPath))
        {
            // Input file does not exist.
            return;
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();
            tiffOptions.CompressionType = Aspose.Slides.Export.TiffCompressionTypes.LZW;
            tiffOptions.DpiX = 150;
            tiffOptions.DpiY = 150;
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported.
        }
        catch (Exception)
        {
            // Handle other exceptions.
        }
    }
}