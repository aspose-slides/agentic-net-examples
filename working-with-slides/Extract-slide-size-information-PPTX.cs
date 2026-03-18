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
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                Aspose.Slides.ISlideSize slideSize = presentation.SlideSize;
                float width = slideSize.Size.Width;
                float height = slideSize.Size.Height;

                int slideCount = presentation.Slides.Count;
                for (int index = 0; index < slideCount; index++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[index];
                    Console.WriteLine($"Slide {slide.SlideNumber}: Width = {width} points, Height = {height} points");
                }

                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}