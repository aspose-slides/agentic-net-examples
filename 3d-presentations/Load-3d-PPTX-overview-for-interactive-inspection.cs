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
            string inputPath = "input.pptx";
            string outputImagePath = "slide0.png";
            string outputPresentationPath = "output.pptx";

            using (Presentation presentation = new Presentation(inputPath))
            {
                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Render the slide (including any 3D content) to an image
                IImage slideImage = slide.GetImage();

                // Save the rendered image as PNG
                slideImage.Save(outputImagePath, Aspose.Slides.ImageFormat.Png);

                // Save the presentation (required before exiting)
                presentation.Save(outputPresentationPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}