using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace GifFromSlides
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output paths
            string inputPath = "input.pptx";
            string outputPath = "output.gif";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load presentation
                Presentation presentation = new Presentation(inputPath);

                // TODO: Select specific slides to include in GIF
                // Example: remove unwanted slides (placeholder logic)
                // int[] slidesToKeep = new int[] {0, 2};
                // // Implementation omitted

                // Configure GIF options
                GifOptions gifOptions = new GifOptions();
                gifOptions.FrameSize = new Size(960, 720);
                gifOptions.DefaultDelay = 2000; // 2 seconds per slide
                gifOptions.TransitionFps = 35;
                // Disposal method set to none is not directly exposed; placeholder comment
                // gifOptions.DisposalMethod = DisposalMethod.None; // Not supported directly

                // Save as GIF
                presentation.Save(outputPath, SaveFormat.Gif, gifOptions);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // TODO: Add handling for unsupported file format
            }
        }
    }
}