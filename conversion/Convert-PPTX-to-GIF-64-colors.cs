using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPptxToGif
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
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Configure GIF export options
                    GifOptions gifOptions = new GifOptions();
                    // Example: set a default delay of 500 ms between frames
                    gifOptions.DefaultDelay = 500;
                    // Note: Aspose.Slides does not provide a direct property to limit the GIF palette to 64 colors.
                    // The closest control is the pixel format, which can be set to an indexed format (8bpp = 256 colors).
                    // For a strict 64‑color palette, additional post‑processing would be required.

                    // Save the presentation as an animated GIF
                    pres.Save(outputPath, SaveFormat.Gif, gifOptions);
                }

                Console.WriteLine("GIF created successfully: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Handle unsupported file format
                Console.WriteLine("The provided file format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., I/O errors, Aspose.Slides errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}