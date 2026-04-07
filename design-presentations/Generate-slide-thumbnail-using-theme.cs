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

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Iterate through each slide and generate a thumbnail
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    ISlide slide = pres.Slides[i];
                    // Create a full‑scale image of the slide
                    IImage image = slide.GetImage(1f, 1f);
                    // Save the thumbnail as JPEG
                    string outputPath = $"Slide_{slide.SlideNumber}.jpg";
                    image.Save(outputPath, Aspose.Slides.ImageFormat.Jpeg);
                }

                // Save the presentation before exiting (no modifications made)
                pres.Save(inputPath, SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}