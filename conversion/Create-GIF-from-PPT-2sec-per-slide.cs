using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace GifPreviewGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPTX file path
            string inputPath = "input.pptx";
            // Output GIF file path
            string outputPath = "preview.gif";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Configure GIF export options: 2 seconds per slide
                GifOptions gifOptions = new GifOptions();
                gifOptions.DefaultDelay = 2000; // 2000 ms = 2 seconds

                // Save the presentation as an animated GIF
                pres.Save(outputPath, SaveFormat.Gif, gifOptions);

                // Dispose the presentation
                pres.Dispose();

                Console.WriteLine("GIF preview generated successfully at: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // The provided file format may not be supported by Aspose.Slides.
            }
        }
    }
}