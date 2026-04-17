using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideExportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "slide1.png";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Calculate pixel dimensions for 300 DPI based on slide size (points to inches conversion)
                    float widthPoints = presentation.SlideSize.Size.Width;
                    float heightPoints = presentation.SlideSize.Size.Height;
                    int widthPixels = (int)(widthPoints / 72f * 300f);
                    int heightPixels = (int)(heightPoints / 72f * 300f);
                    Size imageSize = new Size(widthPixels, heightPixels);

                    // Export the first slide as PNG with the calculated size
                    ISlide slide = presentation.Slides[0];
                    using (IImage image = slide.GetImage(imageSize))
                    {
                        image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                    }

                    // Save the presentation before exiting (no modifications made)
                    presentation.Save(inputPath, SaveFormat.Pptx);
                }
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