using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ThumbnailExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path (first argument or default)
            string inputPath = args.Length > 0 ? args[0] : "sample.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // UNC network share folder for thumbnails
            string uncFolder = @"\\Server\Share\Thumbnails";

            // Ensure the UNC folder exists and is accessible
            try
            {
                if (!Directory.Exists(uncFolder))
                {
                    Directory.CreateDirectory(uncFolder);
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Access denied to network share: " + uncFolder);
                return;
            }

            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Iterate through slides and save thumbnails
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                ISlide slide = presentation.Slides[i];
                IImage slideImage = slide.GetImage(1f, 1f);
                string thumbnailPath = Path.Combine(uncFolder, $"Slide_{i + 1}.png");

                try
                {
                    slideImage.Save(thumbnailPath, Aspose.Slides.ImageFormat.Png);
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Access denied when saving thumbnail: " + thumbnailPath);
                }
                catch (NotSupportedException)
                {
                    // Format not supported comment
                    Console.WriteLine("Image format not supported for: " + thumbnailPath);
                }
                finally
                {
                    slideImage.Dispose();
                }
            }

            // Save the presentation back to the network share
            string presentationOutputPath = Path.Combine(uncFolder, "output.pptx");
            try
            {
                presentation.Save(presentationOutputPath, SaveFormat.Pptx);
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Access denied when saving presentation: " + presentationOutputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported comment
                Console.WriteLine("Presentation format not supported for: " + presentationOutputPath);
            }

            // Dispose the presentation before exit
            presentation.Dispose();
        }
    }
}