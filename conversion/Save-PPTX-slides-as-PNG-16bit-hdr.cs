using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SaveSlidesAsPng16BitHdr
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    for (int index = 0; index < presentation.Slides.Count; index++)
                    {
                        ISlide slide = presentation.Slides[index];
                        // Render slide to image with default scaling (full size)
                        using (IImage slideImage = slide.GetImage(1f, 1f))
                        {
                            string outputPath = $"slide_{index}.png";
                            slideImage.Save(outputPath, Aspose.Slides.ImageFormat.Png);
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
                // Handle other exceptions (e.g., network errors if loading from URL)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}