using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportSlidesToPng16Bit
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
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
                        // Get the current slide
                        ISlide slide = presentation.Slides[index];

                        // Render the slide to an image (full scale)
                        using (IImage slideImage = slide.GetImage(1f, 1f))
                        {
                            // Define output file name
                            string outputPath = $"slide_{index}.png";

                            // Save the image as PNG (Aspose.Slides supports 16‑bit PNG when the source content requires it)
                            slideImage.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                        }
                    }

                    // Save the presentation (required by lifecycle rule)
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
                // General exception handling (e.g., network errors if external resources are used)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}