using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideToGifExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.gif";

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Configure GIF export options
                    GifOptions gifOptions = new GifOptions
                    {
                        // Set frame size (optional)
                        FrameSize = new System.Drawing.Size(960, 720),
                        // Set delay between frames in milliseconds
                        DefaultDelay = 2000,
                        // Increase FPS for smoother transitions
                        TransitionFps = 35
                    };

                    // Save the presentation as an animated GIF
                    presentation.Save(outputPath, SaveFormat.Gif, gifOptions);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during processing
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}