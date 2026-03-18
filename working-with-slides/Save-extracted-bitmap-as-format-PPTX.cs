using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation
                Presentation pres = new Presentation("input.pptx");

                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Render the slide to an image
                IImage slideImage = slide.GetImage();

                // Save the image as PNG
                slideImage.Save("slide0.png", Aspose.Slides.ImageFormat.Png);

                // Save the presentation before exiting
                pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

                // Clean up resources
                slideImage.Dispose();
                pres.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}