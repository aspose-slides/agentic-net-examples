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
            // Input PowerPoint file
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            // Output thumbnail image
            string outputImagePath = Path.Combine(Directory.GetCurrentDirectory(), "slide_thumbnail.png");

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Access first slide
                    ISlide slide = pres.Slides[0];

                    // Generate full-scale thumbnail (scale 1f, 1f)
                    IImage thumbnail = slide.GetImage(1f, 1f);

                    // Save thumbnail as PNG
                    thumbnail.Save(outputImagePath, Aspose.Slides.ImageFormat.Png);

                    // Save presentation before exit (no modifications made)
                    pres.Save(inputPath, SaveFormat.Pptx);
                }

                Console.WriteLine("Thumbnail generated successfully: " + outputImagePath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URL issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}