using System;
using System.IO;
using System.Threading;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ThumbnailGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputFileName = "input.pptx";
            string outputImageFileName = "slide1_thumbnail.jpg";
            string outputPresentationFileName = "output.pptx";

            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), inputFileName);
            string outputImagePath = Path.Combine(Directory.GetCurrentDirectory(), outputImageFileName);
            string outputPresentationPath = Path.Combine(Directory.GetCurrentDirectory(), outputPresentationFileName);

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Desired thumbnail dimensions
                int desiredX = 1200;
                int desiredY = 800;

                // Calculate scaling factors
                float scaleX = (float)(1.0 / presentation.SlideSize.Size.Width) * desiredX;
                float scaleY = (float)(1.0 / presentation.SlideSize.Size.Height) * desiredY;

                // Retry mechanism for thumbnail generation
                int maxRetries = 3;
                int attempt = 0;
                bool success = false;

                while (attempt < maxRetries && !success)
                {
                    try
                    {
                        using (Aspose.Slides.IImage thumbnail = slide.GetImage(scaleX, scaleY))
                        {
                            thumbnail.Save(outputImagePath, Aspose.Slides.ImageFormat.Jpeg);
                        }
                        success = true;
                    }
                    catch (IOException ioEx)
                    {
                        attempt++;
                        if (attempt >= maxRetries)
                        {
                            Console.WriteLine("Failed to generate thumbnail after retries: " + ioEx.Message);
                        }
                        else
                        {
                            // Wait briefly before retrying
                            Thread.Sleep(500);
                        }
                    }
                }

                // Save the presentation (disable thumbnail refresh to keep original thumbnail)
                presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx, new Aspose.Slides.Export.PptxOptions
                {
                    RefreshThumbnail = false
                });
            }
        }
    }
}