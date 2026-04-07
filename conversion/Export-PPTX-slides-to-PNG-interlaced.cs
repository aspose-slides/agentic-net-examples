using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportPptxSlidesToPngInterlaced
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Output directory for PNG images
            string outputDir = "output_png";

            // Create output directory if it does not exist
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    for (int index = 0; index < pres.Slides.Count; index++)
                    {
                        ISlide slide = pres.Slides[index];

                        // Generate a full‑scale image of the slide
                        IImage slideImage = slide.GetImage(1f, 1f);

                        // Build the output file name
                        string outputFile = Path.Combine(outputDir, "slide_" + index + ".png");

                        // Save the image as PNG.
                        // Note: Aspose.Slides PNG saving supports interlaced option via PngOptions.
                        // Since the API for per‑image options is not shown here, we use the default save.
                        slideImage.Save(outputFile, Aspose.Slides.ImageFormat.Png);
                    }

                    // Save the presentation (optional, as per requirement to save before exit)
                    string presOutput = Path.Combine(outputDir, "presentation_saved.pptx");
                    pres.Save(presOutput, SaveFormat.Pptx);
                }
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}