using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideToImageExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                string outputImagePath = "slide_1.jpg";

                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Index of the slide to render (0‑based)
                    int slideIndex = 0;
                    if (slideIndex < 0 || slideIndex >= presentation.Slides.Count)
                    {
                        throw new ArgumentOutOfRangeException("slideIndex", "Slide index is out of range.");
                    }

                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                    // Scale factors for higher resolution (preserve visual fidelity)
                    float scaleX = 2f;
                    float scaleY = 2f;

                    // Render the slide to an image
                    using (Aspose.Slides.IImage image = slide.GetImage(scaleX, scaleY))
                    {
                        image.Save(outputImagePath, Aspose.Slides.ImageFormat.Jpeg);
                    }

                    // Save the presentation before exiting (optional)
                    string savedPath = "output.pptx";
                    presentation.Save(savedPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}