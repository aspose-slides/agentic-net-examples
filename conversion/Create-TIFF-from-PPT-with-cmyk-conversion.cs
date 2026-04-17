using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
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
            var presentation = new Aspose.Slides.Presentation(inputPath);
            var options = new Aspose.Slides.Export.TiffOptions();
            // Set compression type (LZW is default and suitable for print)
            options.CompressionType = Aspose.Slides.Export.TiffCompressionTypes.LZW;
            // CMYK conversion is not directly exposed via TiffOptions; using default color handling.
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, options);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported for conversion.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}