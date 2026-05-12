using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ThumbnailGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";

            // Verify that the file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Generate a thumbnail for each slide
                for (int index = 0; index < presentation.Slides.Count; index++)
                {
                    ISlide slide = presentation.Slides[index];
                    // Create a full‑scale image (1f, 1f) which includes the current theme background
                    IImage image = slide.GetImage(1f, 1f);
                    string outputPath = Path.Combine(Directory.GetCurrentDirectory(), $"Slide_{index + 1}.jpg");
                    // Save the thumbnail as JPEG
                    image.Save(outputPath, Aspose.Slides.ImageFormat.Jpeg);
                    image.Dispose();
                }

                // Save the presentation before exiting (no modifications made)
                presentation.Save(inputPath, SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}