using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ThumbnailGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                string outputImagePath = "thumbnail.png";
                string outputPresentationPath = "output.pptx";

                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Access the first slide
                    ISlide slide = presentation.Slides[0];

                    // Generate a full‑scale thumbnail image
                    using (IImage image = slide.GetImage(1f, 1f))
                    {
                        image.Save(outputImagePath, Aspose.Slides.ImageFormat.Png);
                    }

                    // Save the presentation before exiting
                    presentation.Save(outputPresentationPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}