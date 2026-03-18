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
            string outputImagePath = "slide1.jpg";

            using (Presentation presentation = new Presentation(inputPath))
            {
                // Access the specific slide (first slide in this example)
                ISlide slide = presentation.Slides[0];

                // Generate a full-scale image of the slide
                using (IImage image = slide.GetImage(1f, 1f))
                {
                    image.Save(outputImagePath, Aspose.Slides.ImageFormat.Jpeg);
                }

                // Save the presentation before exiting (no modifications made)
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}