using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportPptToPng
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
                    // Export each slide to PNG with default resolution
                    for (int index = 0; index < presentation.Slides.Count; index++)
                    {
                        ISlide slide = presentation.Slides[index];
                        using (IImage image = slide.GetImage())
                        {
                            string imagePath = Path.Combine(outputDir, $"slide_{index + 1}.png");
                            image.Save(imagePath, Aspose.Slides.ImageFormat.Png);
                        }
                    }

                    // Save presentation before exit (mandatory)
                    presentation.Save(inputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Handle unsupported format scenario
                Console.WriteLine("The presentation format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}