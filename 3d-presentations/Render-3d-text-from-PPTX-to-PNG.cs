using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Render3DShapes
{
    class Program
    {
        static void Main()
        {
            string sourcePath = "input.pptx";
            string outputDirectory = "output";

            try
            {
                using (Presentation presentation = new Presentation(sourcePath))
                {
                    Directory.CreateDirectory(outputDirectory);

                    float scaleX = 2f; // High‑resolution scaling factor
                    float scaleY = 2f;

                    for (int index = 0; index < presentation.Slides.Count; index++)
                    {
                        ISlide slide = presentation.Slides[index];
                        IImage image = slide.GetImage(scaleX, scaleY);
                        string outputPath = Path.Combine(outputDirectory, $"slide_{index + 1}.png");
                        image.Save(outputPath, ImageFormat.Png);
                        image.Dispose();
                    }

                    // Save the presentation before exiting (optional)
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}