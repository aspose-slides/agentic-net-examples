using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportSlidesToJpeg
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation file
            string inputPath = "input.pptx";
            // Output directory for JPEG images
            string outputDir = "output";

            // Check if input file exists
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
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Export each slide to JPEG with quality 90
                    for (int index = 0; index < presentation.Slides.Count; index++)
                    {
                        ISlide slide = presentation.Slides[index];
                        // Use full-scale image (1f, 1f)
                        using (IImage image = slide.GetImage(1f, 1f))
                        {
                            string outputPath = Path.Combine(outputDir, $"Slide_{index + 1}.jpg");
                            // Save with specified quality (0-100)
                            image.Save(outputPath, ImageFormat.Jpeg, 90);
                        }
                    }

                    // Save the presentation before exiting (optional copy)
                    string copyPath = Path.Combine(outputDir, "PresentationCopy.pptx");
                    presentation.Save(copyPath, SaveFormat.Pptx);
                }
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