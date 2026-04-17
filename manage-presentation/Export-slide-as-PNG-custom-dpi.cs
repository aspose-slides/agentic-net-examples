using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideExportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output directory for PNG images
            string outputDir = "output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Create output directory if it does not exist
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            try
            {
                // Load presentation
                Presentation presentation = new Presentation(inputPath);

                // Desired DPI (e.g., 300)
                const float targetDpi = 300f;
                // Default DPI assumed by Aspose.Slides is 96
                const float defaultDpi = 96f;
                float scaleFactor = targetDpi / defaultDpi;

                // Export each slide as high‑quality PNG
                for (int index = 0; index < presentation.Slides.Count; index++)
                {
                    ISlide slide = presentation.Slides[index];
                    using (IImage image = slide.GetImage(scaleFactor, scaleFactor))
                    {
                        string imagePath = Path.Combine(outputDir, $"slide_{index + 1}.png");
                        image.Save(imagePath, Aspose.Slides.ImageFormat.Png);
                    }
                }

                // Save presentation before exit (optional, can overwrite original)
                presentation.Save(inputPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URL issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}