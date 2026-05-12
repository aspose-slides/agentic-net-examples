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
            string outputDir = "output_images";
            string outputPresentation = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    int slideCount = presentation.Slides.Count;
                    for (int i = 0; i < slideCount; i++)
                    {
                        ISlide slide = presentation.Slides[i];
                        float scaleX = 3f;
                        float scaleY = 3f;
                        using (IImage image = slide.GetImage(scaleX, scaleY))
                        {
                            string imagePath = Path.Combine(outputDir, $"slide_{i + 1}.png");
                            image.Save(imagePath, Aspose.Slides.ImageFormat.Png);
                        }
                    }

                    // Save presentation before exit
                    presentation.Save(outputPresentation, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}