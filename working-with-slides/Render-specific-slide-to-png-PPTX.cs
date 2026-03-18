using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RenderSlideToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input presentation file path
                string inputPath = Path.Combine("Data", "sample.pptx");
                // Output directory for the rendered image and saved presentation
                string outputDir = "Output";

                // Ensure output directory exists
                Directory.CreateDirectory(outputDir);

                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Index of the slide to render (0‑based)
                    int slideIndex = 0;

                    // Get the specific slide
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                    // Render the slide to an image (default 20% size)
                    Aspose.Slides.IImage slideImage = slide.GetImage();

                    // Save the rendered image as PNG
                    string imagePath = Path.Combine(outputDir, $"slide_{slideIndex + 1}.png");
                    slideImage.Save(imagePath, Aspose.Slides.ImageFormat.Png);

                    // Save the presentation before exiting (required by lifecycle rule)
                    string savedPresentationPath = Path.Combine(outputDir, "savedPresentation.pptx");
                    presentation.Save(savedPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}