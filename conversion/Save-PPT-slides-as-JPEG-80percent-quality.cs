using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideToJpeg
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPT file path
            string inputPath = "input.pptx";
            // Output directory for JPEG images
            string outputDir = "OutputImages";

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
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                // Iterate through slides and save each as JPEG with 80% quality
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    Aspose.Slides.ISlide slide = pres.Slides[i];
                    Aspose.Slides.IImage image = slide.GetImage(1f, 1f);
                    string outputPath = Path.Combine(outputDir, $"Slide_{i + 1}.jpg");
                    // Save with quality parameter (0-100)
                    image.Save(outputPath, Aspose.Slides.ImageFormat.Jpeg, 80);
                }

                // Save presentation before exit (optional, preserving original)
                string savedPath = Path.Combine(outputDir, "SavedPresentation.pptx");
                pres.Save(savedPath, Aspose.Slides.Export.SaveFormat.Pptx);
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