using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideExportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation
                Presentation presentation = new Presentation("input.pptx");

                // Specify the slide number to export (1‑based index)
                int slideNumber = 2;
                ISlide slide = presentation.Slides[slideNumber - 1];

                // Render the slide to an image with default scaling
                IImage slideImage = slide.GetImage();

                // Save the image as PNG using the correct ImageFormat namespace
                slideImage.Save("slide2.png", Aspose.Slides.ImageFormat.Png);

                // Save the presentation (no modifications) before exiting
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}