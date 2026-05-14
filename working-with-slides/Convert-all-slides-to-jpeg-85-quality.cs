using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchConvertSlides
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output directory for JPEG images
            string outputDir = "output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            try
            {
                // Load presentation
                Presentation presentation = new Presentation(inputPath);

                // Iterate through all slides and save each as JPEG with 85% quality
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    ISlide slide = presentation.Slides[i];
                    // Get full‑scale image of the slide
                    IImage image = slide.GetImage(1f, 1f);
                    // Build output file name
                    string outputPath = Path.Combine(outputDir, $"slide_{i + 1}.jpg");
                    // Save image as JPEG with quality = 85
                    image.Save(outputPath, Aspose.Slides.ImageFormat.Jpeg, 85);
                }

                // Save presentation before exiting (no modifications made)
                presentation.Save(inputPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Handle unsupported format scenario here
                Console.WriteLine("The presentation format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}