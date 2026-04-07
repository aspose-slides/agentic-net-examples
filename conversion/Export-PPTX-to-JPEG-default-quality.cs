using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideToJpegExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input PPTX file and output directory
            string inputPath = "input.pptx";
            string outputDir = "output";

            // Verify input file exists
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
                // Load presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Export each slide to JPEG with default quality
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        ISlide slide = presentation.Slides[i];
                        IImage image = slide.GetImage(1f, 1f);
                        string outputPath = Path.Combine(outputDir, $"Slide_{i + 1}.jpg");
                        image.Save(outputPath, Aspose.Slides.ImageFormat.Jpeg);
                    }

                    // Save presentation before exit (optional, can be same as input or new file)
                    string savedPath = "saved_output.pptx";
                    presentation.Save(savedPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported for this operation.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}