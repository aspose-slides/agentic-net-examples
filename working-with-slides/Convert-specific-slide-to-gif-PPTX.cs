using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideToGif
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string presentationPath = "input.pptx";
                string outputImagePath = "slide1.gif";

                // Load the presentation
                using (Presentation pres = new Presentation(presentationPath))
                {
                    // Access the first slide (index 0)
                    ISlide slide = pres.Slides[0];

                    // Create a high‑resolution image of the slide
                    using (IImage image = slide.GetImage(2f, 2f))
                    {
                        // Save the image as GIF
                        image.Save(outputImagePath, Aspose.Slides.ImageFormat.Gif);
                    }

                    // Save the presentation before exiting (no modifications made)
                    pres.Save(presentationPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}