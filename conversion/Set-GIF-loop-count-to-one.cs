using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SetGifLoopCount
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
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Configure GIF export options
                    GifOptions gifOptions = new GifOptions
                    {
                        // Aspose.Slides does not expose a LoopCount property.
                        // Non‑looping GIFs are not directly supported via GifOptions.
                        // The default behavior is to loop; additional processing would be required.
                        DefaultDelay = 1000 // example delay per frame
                    };

                    // Save as animated GIF
                    presentation.Save(outputPath, SaveFormat.Gif, gifOptions);
                }

                Console.WriteLine($"Presentation saved as GIF: {outputPath}");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The requested format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file access issues)
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}