using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlidesGifDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputGifPath = "output.gif";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Save the presentation before exiting (as required)
                    pres.Save("temp.pptx", SaveFormat.Pptx);

                    // Create animations generator
                    using (PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(pres))
                    {
                        // Loop count of 3 repetitions is not directly supported by Aspose.Slides GIF export.
                        // The generated GIF will use the default looping behavior.

                        // Create a player (FPS can be adjusted as needed)
                        using (PresentationPlayer player = new PresentationPlayer(animationsGenerator, 30))
                        {
                            // Configure GIF export options
                            GifOptions gifOptions = new GifOptions();
                            gifOptions.FrameSize = new Size(960, 720);
                            gifOptions.DefaultDelay = 500; // 500 ms per frame

                            // Export the presentation as an animated GIF
                            pres.Save(outputGifPath, SaveFormat.Gif, gifOptions);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                // If the format is not supported, handle accordingly
                // Format not supported.
            }
        }
    }
}