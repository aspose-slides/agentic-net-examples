using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "input.pptx";
            var outputImagePath = "slide1.jpg";

            using (var pres = new Aspose.Slides.Presentation(inputPath))
            {
                // Save the presentation before exiting
                pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

                var slideIndex = 0; // index of the slide to convert
                var slide = pres.Slides[slideIndex];

                // High‑resolution scaling factors
                var scaleX = 2f;
                var scaleY = 2f;

                using (var image = slide.GetImage(scaleX, scaleY))
                {
                    image.Save(outputImagePath, Aspose.Slides.ImageFormat.Jpeg);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}