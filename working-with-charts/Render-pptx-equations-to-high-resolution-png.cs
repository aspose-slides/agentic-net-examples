using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RenderMathSlides
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file containing equations
            string inputPath = "input.pptx";
            // Directory to store rendered PNG images
            string outputDirectory = "output";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Ensure the output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // High‑resolution scaling factors
                float scaleX = 3f;
                float scaleY = 3f;

                // Iterate through each slide and render to PNG
                for (int index = 0; index < presentation.Slides.Count; index++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[index];
                    Aspose.Slides.IImage image = slide.GetImage(scaleX, scaleY);
                    string outputPath = Path.Combine(outputDirectory, $"slide_{index + 1}.png");
                    image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                    image.Dispose();
                }

                // Save the presentation (required before exit)
                presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}