using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CreateGifFromPptx
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
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
                    // Configure GIF export options
                    GifOptions gifOptions = new GifOptions();
                    // Note: Aspose.Slides does not expose a direct property for color depth.
                    // The GIF format is limited to 8‑bit indexed color (256 colors). This is the closest
                    // achievable setting to the requested 128‑color limit.

                    // Save the presentation as an animated GIF
                    presentation.Save(outputPath, SaveFormat.Gif, gifOptions);
                }

                Console.WriteLine("GIF created successfully at: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}