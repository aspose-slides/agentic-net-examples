using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ThumbnailBatchResize
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Output directory for thumbnails
            string outputDir = "Thumbnails";
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            try
            {
                // Load presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Desired maximum width in pixels
                float maxWidth = 200f;

                // Calculate scaling factor based on slide width (preserve aspect ratio)
                float slideWidth = presentation.SlideSize.Size.Width;
                float scaleFactor = maxWidth / slideWidth;

                // Generate and save thumbnails for each slide
                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    using (Aspose.Slides.IImage thumbnail = slide.GetImage(scaleFactor, scaleFactor))
                    {
                        string imagePath = Path.Combine(outputDir, $"Slide_{slide.SlideNumber}.jpg");
                        thumbnail.Save(imagePath, Aspose.Slides.ImageFormat.Jpeg);
                    }
                }

                // Save presentation before exit (no modifications made)
                presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
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