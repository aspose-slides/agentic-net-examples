using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.gif";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                {
                    // Apply fade transition effect to the first slide
                    pres.Slides[0].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;

                    // Configure GIF export options with a higher transition FPS
                    Aspose.Slides.Export.GifOptions gifOptions = new Aspose.Slides.Export.GifOptions();
                    gifOptions.TransitionFps = 60;
                    gifOptions.FrameSize = new System.Drawing.Size(960, 720);

                    // Save the presentation as an animated GIF
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Gif, gifOptions);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}