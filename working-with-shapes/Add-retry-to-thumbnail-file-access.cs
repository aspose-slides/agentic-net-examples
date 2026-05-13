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
            // Define input and output file names
            string inputFileName = "input.pptx";
            string outputImagePath = "slide_thumbnail.jpg";
            string outputPresentationPath = "output.pptx";

            // Build full paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), inputFileName);
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), outputImagePath);
            string presentationPath = Path.Combine(Directory.GetCurrentDirectory(), outputPresentationPath);

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            Presentation presentation = null;
            try
            {
                presentation = new Presentation(inputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Retry mechanism for thumbnail generation
            int maxAttempts = 3;
            int attempt = 0;
            bool success = false;
            while (attempt < maxAttempts && !success)
            {
                try
                {
                    // Generate thumbnail with full scale (1f, 1f)
                    IImage thumbnail = slide.GetImage(1f, 1f);
                    // Save the thumbnail as JPEG
                    thumbnail.Save(imagePath, Aspose.Slides.ImageFormat.Jpeg);
                    thumbnail.Dispose();
                    success = true;
                }
                catch (IOException ioEx)
                {
                    // Temporary file access issue, wait and retry
                    attempt++;
                    Console.WriteLine("Attempt " + attempt + " failed due to file access issue: " + ioEx.Message);
                    System.Threading.Thread.Sleep(500);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Thumbnail generation failed: " + ex.Message);
                    break;
                }
            }

            if (!success)
            {
                Console.WriteLine("Failed to generate thumbnail after multiple attempts.");
            }

            // Save the presentation (ensuring thumbnail refresh is disabled to keep original thumbnail)
            try
            {
                presentation.Save(presentationPath, SaveFormat.Pptx, new PptxOptions
                {
                    RefreshThumbnail = false
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }

            // Clean up
            presentation.Dispose();
        }
    }
}