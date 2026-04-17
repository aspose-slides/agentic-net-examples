using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchConvertSlidesToJpeg
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

            try
            {
                // Load presentation
                Presentation presentation = new Presentation(inputPath);

                // Ensure output directory exists
                Directory.CreateDirectory(outputDir);

                // Iterate through all slides and save as JPEG with 85% quality
                for (int index = 0; index < presentation.Slides.Count; index++)
                {
                    ISlide slide = presentation.Slides[index];
                    IImage image = slide.GetImage(1f, 1f);
                    string outputPath = Path.Combine(outputDir, $"slide_{index + 1}.jpg");
                    // Save image with specified quality
                    image.Save(outputPath, Aspose.Slides.ImageFormat.Jpeg, 85);
                }

                // Save presentation before exit (as per lifecycle rule)
                presentation.Save(inputPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Handle unsupported format scenario
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