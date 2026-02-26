using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using Aspose.Slides;

namespace ConvertPresentationToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file
            string inputPath = "input.pptx";

            // Output folder for PNG images
            string outputFolder = "output";

            // Ensure the output directory exists
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Define custom image size (width x height in pixels)
            Size customSize = new Size(960, 720);

            // Iterate through each slide and save as PNG with custom dimensions
            for (int index = 0; index < presentation.Slides.Count; index++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[index];
                Aspose.Slides.IImage image = slide.GetImage(customSize);
                string outputPath = Path.Combine(outputFolder, $"slide_{index}.png");
                image.Save(outputPath, ImageFormat.Png);
                image.Dispose();
            }

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}