using System;
using System.IO;
using System.Drawing.Imaging;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPresentationToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file
            string inputPath = "input.pptx";
            // Output folder for PNG images
            string outputFolder = "output_png";

            // Ensure the output directory exists
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // High‑quality scaling factors (2x)
                float scaleX = 2f;
                float scaleY = 2f;

                // Iterate through all slides and save each as a PNG image
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[i];
                    Aspose.Slides.IImage image = slide.GetImage(scaleX, scaleY);
                    string outputPath = Path.Combine(outputFolder, $"slide_{i + 1}.png");
                    image.Save(outputPath, ImageFormat.Png);
                    image.Dispose();
                }

                // Save the presentation before exiting (as required by authoring rules)
                string savedPresentationPath = "saved_presentation.pptx";
                presentation.Save(savedPresentationPath, SaveFormat.Pptx);
            }
        }
    }
}