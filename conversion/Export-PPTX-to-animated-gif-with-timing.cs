using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationToGif
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the source presentation
                using (Presentation presentation = new Presentation("input.pptx"))
                {
                    // Configure GIF export options
                    var gifOptions = new GifOptions
                    {
                        FrameSize = new Size(960, 720),      // Size of the resulting GIF
                        DefaultDelay = 2000,                // Delay per slide in milliseconds
                        TransitionFps = 35                  // Frames per second for transitions
                    };

                    // Save the presentation as an animated GIF
                    presentation.Save("output.gif", SaveFormat.Gif, gifOptions);
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