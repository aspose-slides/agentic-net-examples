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
            // Define input and output presentation paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
            string thumbnailPath = Path.Combine(Directory.GetCurrentDirectory(), "thumb.jpg");

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Optional: clear shapes on the first slide (as per refresh-thumbnail-presentation rule)
                presentation.Slides[0].Shapes.Clear();

                // Retry mechanism for thumbnail generation
                int maxAttempts = 3;
                int attempt = 0;
                bool thumbnailCreated = false;
                while (!thumbnailCreated && attempt < maxAttempts)
                {
                    try
                    {
                        // Generate a full‑scale thumbnail for the first slide
                        IImage thumbnail = presentation.Slides[0].GetImage(1f, 1f);
                        // Save the thumbnail as JPEG
                        thumbnail.Save(thumbnailPath, Aspose.Slides.ImageFormat.Jpeg);
                        thumbnailCreated = true;
                    }
                    catch (IOException)
                    {
                        // Temporary file access issue – wait and retry
                        attempt++;
                        Thread.Sleep(500);
                    }
                }

                if (!thumbnailCreated)
                {
                    Console.WriteLine("Failed to generate thumbnail after multiple attempts.");
                }

                // Save the presentation without refreshing the thumbnail (as per rule)
                presentation.Save(outputPath, SaveFormat.Pptx, new PptxOptions
                {
                    RefreshThumbnail = false
                });

                // Dispose the presentation object
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}