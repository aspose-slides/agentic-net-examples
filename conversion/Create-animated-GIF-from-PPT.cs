using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesGifExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                string outputPath = "output.gif";

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    Aspose.Slides.Export.GifOptions gifOptions = new Aspose.Slides.Export.GifOptions();
                    gifOptions.FrameSize = new Size(960, 720);          // Set GIF frame size
                    gifOptions.DefaultDelay = 2000;                    // Delay per frame in ms
                    gifOptions.TransitionFps = 35;                     // Frames per second for transitions

                    presentation.Save(outputPath, SaveFormat.Gif, gifOptions);
                }

                Console.WriteLine("Animated GIF created successfully at: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}