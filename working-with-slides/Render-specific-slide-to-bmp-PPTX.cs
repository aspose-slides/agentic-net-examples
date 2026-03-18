using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentationPath = "input.pptx";
            var outputImagePath = "slide0.bmp";

            using var pres = new Presentation(presentationPath);
            var slide = pres.Slides[0];
            using var image = slide.GetImage(1f, 1f);
            image.Save(outputImagePath, Aspose.Slides.ImageFormat.Bmp);

            // Save the presentation before exiting (if any modifications were made)
            pres.Save("output.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}