using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for input and output files
            string inputPath = "input.pptx";
            string outputPathWithInk = "slide_with_ink.png";
            string outputPathWithoutInk = "slide_without_ink.png";
            string savedPresentationPath = "output.pptx";

            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Get the first slide
                ISlide firstSlide = pres.Slides[0];

                // Export the slide with ink strokes visible
                using (IImage imageWithInk = firstSlide.GetImage())
                {
                    imageWithInk.Save(outputPathWithInk, Aspose.Slides.ImageFormat.Png);
                }

                // Export the same slide without ink strokes
                RenderingOptions renderingOpts = new RenderingOptions();
                renderingOpts.InkOptions.HideInk = true;
                using (IImage imageWithoutInk = firstSlide.GetImage(renderingOpts))
                {
                    imageWithoutInk.Save(outputPathWithoutInk, Aspose.Slides.ImageFormat.Png);
                }

                // Save the (unchanged) presentation before exiting
                pres.Save(savedPresentationPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}