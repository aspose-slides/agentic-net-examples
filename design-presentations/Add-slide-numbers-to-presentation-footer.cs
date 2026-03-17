using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            int slideCount = presentation.Slides.Count;
            for (int i = 0; i < slideCount; i++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[i];
                slide.HeaderFooterManager.SetSlideNumberVisibility(true);
                slide.HeaderFooterManager.SetFooterVisibility(true);
            }

            presentation.Save("SlideNumbers.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}