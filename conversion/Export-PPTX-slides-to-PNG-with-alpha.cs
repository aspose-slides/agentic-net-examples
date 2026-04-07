using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportSlidesToPng
{
    class Program
    {
        static void Main(string[] args)
        {
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
                    // Iterate through each slide and export as PNG with transparency
                    for (int index = 0; index < presentation.Slides.Count; index++)
                    {
                        ISlide slide = presentation.Slides[index];
                        using (IImage image = slide.GetImage(1f, 1f))
                        {
                            string outputPath = $"slide_{index}.png";
                            image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                        }
                    }

                    // Save the presentation before exiting (no modifications made)
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URLs or I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}