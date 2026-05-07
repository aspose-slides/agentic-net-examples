using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace WatermarkGifExample
{
    class Program
    {
        static void Main()
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.gif";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found.");
                return;
            }

            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Add a semi‑transparent logo watermark to the first master slide
                IMasterSlide master = pres.Masters[0];
                IAutoShape watermarkShape = master.Shapes.AddAutoShape(
                    ShapeType.Rectangle, 100, 100, 200, 50);
                watermarkShape.AddTextFrame("Logo");
                watermarkShape.TextFrame.TextFrameFormat.CenterText = NullableBool.True;
                watermarkShape.FillFormat.FillType = FillType.NoFill;
                watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;

                // Convert the presentation to an animated GIF
                try
                {
                    GifOptions gifOptions = new GifOptions();
                    gifOptions.TransitionFps = 30; // Set desired FPS
                    pres.Save(outputPath, SaveFormat.Gif, gifOptions);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                }
            }
        }
    }
}