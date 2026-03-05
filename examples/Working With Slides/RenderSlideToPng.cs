using System;
using System.Drawing.Imaging;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideToPngExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source PPTX file
            string sourcePath = "input.pptx";
            // Path for the output PNG file of the specific slide
            string outputPath = "slide_1.png";

            // Load the presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(sourcePath))
            {
                // Get the first slide (index 0)
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Render the slide to an image
                using (Aspose.Slides.IImage image = slide.GetImage())
                {
                    // Save the image as PNG
                    image.Save(outputPath, ImageFormat.Png);
                }

                // Save the presentation before exiting (as required)
                pres.Save(sourcePath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}