using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideExportApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                string outputImagePath = "slide1.jpg";

                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Select the first slide (index 0)
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Generate a high‑resolution image (2x scaling)
                Aspose.Slides.IImage image = slide.GetImage(2f, 2f);

                // Save as JPEG with maximum quality (100)
                image.Save(outputImagePath, Aspose.Slides.ImageFormat.Jpeg, 100);

                // Save the presentation before exiting (no modifications made)
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}