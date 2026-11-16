// -----------------------------------------------------------------------------
// Example: Add retry to thumbnail file access using C#
// 
// Description:
// Demonstrates generating a JPEG thumbnail of the first slide in a PowerPoint
// presentation with a retry mechanism for temporary file access issues. The
// program creates a sample presentation if none exists, saves the thumbnail,
// and then saves the presentation without refreshing its thumbnail.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Retry, Thumbnail, File Access
// 
// Use Cases:
// - Automate thumbnail generation with resilience to file access conflicts.
// - Build C# tools for PowerPoint processing that require reliable image extraction.
// - Preserve existing presentation thumbnails while performing other modifications.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using System.Threading;

namespace ThumbnailGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFileName = "input.pptx";
            string outputImageFileName = "slide_thumbnail.jpg";
            string outputPresentationFileName = "output.pptx";

            string currentDirectory = Directory.GetCurrentDirectory();
            string inputFilePath = Path.Combine(currentDirectory, inputFileName);
            string imageFilePath = Path.Combine(currentDirectory, outputImageFileName);
            string outputPresentationPath = Path.Combine(currentDirectory, outputPresentationFileName);

            // Ensure input presentation exists; create a simple one if missing
            if (!File.Exists(inputFilePath))
            {
                try
                {
                    Aspose.Slides.Presentation createPres = new Aspose.Slides.Presentation();
                    // The default presentation already contains one slide
                    createPres.Save(inputFilePath, Aspose.Slides.Export.SaveFormat.Pptx);
                    createPres.Dispose();
                    Console.WriteLine("Created sample presentation: " + inputFilePath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to create sample presentation: " + ex.Message);
                    Environment.Exit(1);
                }
            }

            // Load the presentation
            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputFilePath);
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("The file format is not supported.");
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                Environment.Exit(1);
            }

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Retry mechanism for thumbnail generation
            int maxAttempts = 3;
            int attempt = 0;
            bool success = false;
            while (attempt < maxAttempts && !success)
            {
                try
                {
                    Aspose.Slides.IImage thumbnail = slide.GetImage(1f, 1f);
                    thumbnail.Save(imageFilePath, Aspose.Slides.ImageFormat.Jpeg);
                    thumbnail.Dispose();
                    success = true;
                }
                catch (IOException ioEx)
                {
                    attempt++;
                    Console.WriteLine("Attempt " + attempt + " failed due to file access issue: " + ioEx.Message);
                    Thread.Sleep(500);
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
                presentation.Dispose();
                Environment.Exit(1);
            }

            // Save the presentation without refreshing its thumbnail
            try
            {
                Aspose.Slides.Export.PptxOptions saveOptions = new Aspose.Slides.Export.PptxOptions();
                saveOptions.RefreshThumbnail = false;
                presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx, saveOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save presentation: " + ex.Message);
                presentation.Dispose();
                Environment.Exit(1);
            }

            // Clean up
            presentation.Dispose();
            Console.WriteLine("Thumbnail saved to: " + imageFilePath);
            Console.WriteLine("Presentation saved to: " + outputPresentationPath);
            Environment.Exit(0);
        }
    }
}
