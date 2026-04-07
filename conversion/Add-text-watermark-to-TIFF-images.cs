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
            // Input PowerPoint file
            string inputPath = "input.pptx";
            // Output TIFF file
            string outputPath = "output.tiff";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Add watermark text to the master slide (applies to all slides)
                Aspose.Slides.IMasterSlide master = presentation.Masters[0];
                Aspose.Slides.IAutoShape watermarkShape = master.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle,
                    0, 0, 300, 50);
                watermarkShape.AddTextFrame("Confidential");
                watermarkShape.TextFrame.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;
                watermarkShape.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
                watermarkShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.NoFill;

                // Configure TIFF options (example: 8bpp indexed pixel format)
                Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();
                tiffOptions.PixelFormat = Aspose.Slides.Export.ImagePixelFormat.Format8bppIndexed;

                // Save the presentation as a multi-page TIFF with the watermark applied
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);

                // Dispose presentation resources
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Handle unsupported file format
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}