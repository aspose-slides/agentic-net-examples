using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesGifExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPTX file path
            string inputPath = "input.pptx";
            // Output GIF file path
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
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Configure GIF export options with a 200 ms frame delay
                    GifOptions gifOptions = new GifOptions();
                    gifOptions.DefaultDelay = 200; // 200 milliseconds per frame

                    // Save the presentation as an animated GIF
                    presentation.Save(outputPath, SaveFormat.Gif, gifOptions);
                }

                Console.WriteLine("GIF animation created successfully at: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Handle unsupported file format
                Console.WriteLine("The provided file format is not supported for GIF conversion.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors, Aspose.Slides errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}