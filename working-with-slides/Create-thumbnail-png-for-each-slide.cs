using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideThumbnailGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output directory for thumbnails
            string outputDir = "thumbnails";

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

                // Fixed thumbnail size
                Size thumbnailSize = new Size(200, 150);

                // Iterate through each slide and generate PNG thumbnail
                for (int index = 0; index < presentation.Slides.Count; index++)
                {
                    ISlide slide = presentation.Slides[index];
                    IImage thumbnail = slide.GetImage(thumbnailSize);
                    string outputPath = Path.Combine(outputDir, $"slide_{index + 1}.png");
                    thumbnail.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                }

                // Save the presentation before exiting
                string savedPresentationPath = "output.pptx";
                presentation.Save(savedPresentationPath, SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}