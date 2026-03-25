using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportEquations
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the input presentation
            string inputPath = "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file not found - " + inputPath);
                return;
            }

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate through all slides
                int slideIndex = 0;
                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    // Render the slide (including equations) to an image
                    Aspose.Slides.IImage slideImage = slide.GetImage();

                    // Define output PNG file name
                    string outputImagePath = $"slide_{slideIndex}.png";

                    // Save the image as PNG
                    slideImage.Save(outputImagePath, Aspose.Slides.ImageFormat.Png);

                    // Dispose the image to free resources
                    slideImage.Dispose();

                    slideIndex++;
                }

                // Save the (potentially unchanged) presentation before exiting
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}