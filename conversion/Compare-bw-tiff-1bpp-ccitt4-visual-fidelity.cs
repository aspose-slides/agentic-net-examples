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
                options.CompressionType = Aspose.Slides.Export.TiffCompressionTypes.CCITT4;
                options.BwConversionMode = Aspose.Slides.Export.BlackWhiteConversionMode.Dithering;
                options.PixelFormat = Aspose.Slides.Export.ImagePixelFormat.Format1bppIndexed;
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, options);
                // Compare visual fidelity between original and generated TIFF (implementation omitted)
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
}