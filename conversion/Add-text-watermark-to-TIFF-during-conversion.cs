using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace WatermarkTiffConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.tiff";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                // Add watermark text to the first master slide
                Aspose.Slides.IMasterSlide master = pres.Masters[0];
                Aspose.Slides.IAutoShape watermarkShape = master.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle,
                    0, 0, 500, 50);
                watermarkShape.AddTextFrame("CONFIDENTIAL");
                watermarkShape.TextFrame.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;
                watermarkShape.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
                watermarkShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.NoFill;

                // Configure TIFF options (optional customizations)
                Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();
                // Example: set pixel format to 8bpp indexed
                tiffOptions.PixelFormat = Aspose.Slides.Export.ImagePixelFormat.Format8bppIndexed;

                // Save the presentation as TIFF with watermark applied
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);

                // Ensure the presentation is saved before exit
                pres.Dispose();

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
                Console.WriteLine("The provided file format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URLs, web services)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}