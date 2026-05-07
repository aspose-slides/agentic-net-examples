using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideToPngConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPTX file path
            string inputPath = "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    for (int index = 0; index < presentation.Slides.Count; index++)
                    {
                        ISlide slide = presentation.Slides[index];
                        // Export each slide as a PNG image using lossless compression
                        using (IImage image = slide.GetImage())
                        {
                            string outputPath = $"slide_{index}.png";
                            image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                        }
                    }

                    // Save the presentation (no modifications, but required by lifecycle rule)
                    presentation.Save("output.pptx", SaveFormat.Pptx);
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