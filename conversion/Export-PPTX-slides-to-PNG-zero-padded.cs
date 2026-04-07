using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportPptxToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPTX file path
            string inputPath = "input.pptx";

            // Output directory for PNG files
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
                    // Determine zero‑padding width based on slide count
                    int slideCount = presentation.Slides.Count;
                    int paddingWidth = slideCount.ToString().Length;

                    // Export each slide to PNG with zero‑padded index
                    for (int index = 0; index < slideCount; index++)
                    {
                        ISlide slide = presentation.Slides[index];
                        using (IImage image = slide.GetImage())
                        {
                            string fileName = "slide_" + (index + 1).ToString("D" + paddingWidth) + ".png";
                            string outputPath = Path.Combine(outputDir, fileName);
                            image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                        }
                    }

                    // Save presentation before exit (optional, can overwrite original)
                    presentation.Save(inputPath, SaveFormat.Pptx);
                }
            }
            catch (PptxUnsupportedFormatException)
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