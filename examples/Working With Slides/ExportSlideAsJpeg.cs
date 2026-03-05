using System;
using System.Drawing.Imaging;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the source PPTX file
        string sourceFile = "input.pptx";
        // Path for the exported JPEG image
        string jpegFile = "slide1.jpg";

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourceFile))
        {
            // Get the first slide (index 0)
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Render the slide to an image with full scale
            using (Aspose.Slides.IImage image = slide.GetImage(1f, 1f))
            {
                // Save the image as JPEG
                image.Save(jpegFile, ImageFormat.Jpeg);
            }

            // Save the presentation (required before exiting)
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}