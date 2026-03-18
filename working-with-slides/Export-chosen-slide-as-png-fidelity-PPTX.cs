using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputImagePath = "slide1.png";

            using (Presentation presentation = new Presentation(inputPath))
            {
                int slideIndex = 0; // zero‑based index of the slide to export
                ISlide slide = presentation.Slides[slideIndex];

                float scaleX = 2f;
                float scaleY = 2f;

                using (IImage image = slide.GetImage(scaleX, scaleY))
                {
                    image.Save(outputImagePath, Aspose.Slides.ImageFormat.Png);
                }

                // Save the presentation (no modifications) before exiting
                presentation.Save(inputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}