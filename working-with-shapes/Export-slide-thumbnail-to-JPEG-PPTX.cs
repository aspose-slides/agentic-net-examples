using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input presentation file
            var inputPath = "input.pptx";
            // Output thumbnail image file
            var outputImagePath = "slide_thumbnail.jpg";

            // Load the presentation
            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Get the first slide
                var slide = presentation.Slides[0];

                // Generate a high‑quality image (scale 2x)
                var image = slide.GetImage(2f, 2f);
                using (image)
                {
                    // Save the thumbnail as JPEG
                    image.Save(outputImagePath, Aspose.Slides.ImageFormat.Jpeg);
                }

                // Save the presentation before exiting (optional, can be same file)
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}