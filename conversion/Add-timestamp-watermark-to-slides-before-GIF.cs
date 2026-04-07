using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TimestampWatermarkGif
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.gif";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                // Add a timestamp watermark to the master slide (appears on all slides)
                Aspose.Slides.IMasterSlide master = pres.Masters[0];
                Aspose.Slides.IAutoShape watermarkShape = master.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle,
                    10, 10, 500, 30);
                watermarkShape.AddTextFrame(DateTime.Now.ToString("g"));
                watermarkShape.TextFrame.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;
                watermarkShape.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
                watermarkShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.NoFill;

                // Save the presentation as an animated GIF
                Aspose.Slides.Export.GifOptions gifOptions = new Aspose.Slides.Export.GifOptions();
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Gif, gifOptions);

                // Save the modified presentation (optional)
                pres.Save("watermarked.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}