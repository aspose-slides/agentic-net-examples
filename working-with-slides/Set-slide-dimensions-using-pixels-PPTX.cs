using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                // Set slide size using a predefined enum (16:9 aspect ratio)
                pres.SlideSize.SetSize(Aspose.Slides.SlideSizeType.OnScreen16x9, Aspose.Slides.SlideSizeScaleType.DoNotScale);

                // Set slide size using pixel values (convert pixels to points assuming 96 DPI)
                float widthPixels = 1280f;
                float heightPixels = 720f;
                float dpi = 96f;
                float widthPoints = widthPixels * 72f / dpi;
                float heightPoints = heightPixels * 72f / dpi;
                pres.SlideSize.SetSize(widthPoints, heightPoints, Aspose.Slides.SlideSizeScaleType.DoNotScale);

                // Set slide size using inches (convert inches to points)
                float widthInches = 10f;
                float heightInches = 5.625f; // 10 inches * 0.5625 = 5.625 inches for 16:9 ratio
                float widthPointsInches = widthInches * 72f;
                float heightPointsInches = heightInches * 72f;
                pres.SlideSize.SetSize(widthPointsInches, heightPointsInches, Aspose.Slides.SlideSizeScaleType.DoNotScale);

                // Save the presentation
                pres.Save("ConfiguredSlideSize.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}