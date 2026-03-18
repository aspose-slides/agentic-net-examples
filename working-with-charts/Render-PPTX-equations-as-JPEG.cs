using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Define scaling factors for high‑resolution output
            float scaleX = 2f;
            float scaleY = 2f;

            // Render each slide (assumed to contain a mathematical equation) as a JPEG image
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[i];
                using (Aspose.Slides.IImage image = slide.GetImage(scaleX, scaleY))
                {
                    string outputPath = $"Slide_{i + 1}.jpg";
                    image.Save(outputPath, Aspose.Slides.ImageFormat.Jpeg);
                }
            }

            // Save the presentation before exiting
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}