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
            // Input PPTX file path
            string inputPath = "input.pptx";
            // Output folder for PNG thumbnails
            string outputFolder = "thumbnails";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            try
            {
                // Load presentation
                Presentation pres = new Presentation(inputPath);

                // Determine scaling factor to limit max dimension to 200 pixels
                float slideWidth = pres.SlideSize.Size.Width;
                float slideHeight = pres.SlideSize.Size.Height;
                float maxDimension = Math.Max(slideWidth, slideHeight);
                float scale = 200f / maxDimension;

                int slideIndex = 0;
                foreach (ISlide slide in pres.Slides)
                {
                    // Generate thumbnail with calculated scale
                    using (IImage thumbnail = slide.GetImage(scale, scale))
                    {
                        string outputPng = Path.Combine(outputFolder, $"slide_{slideIndex}.png");
                        thumbnail.Save(outputPng, Aspose.Slides.ImageFormat.Png);
                    }
                    slideIndex++;
                }

                // Save presentation before exit
                pres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URLs or web services)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}