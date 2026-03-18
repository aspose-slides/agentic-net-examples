using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (Aspose.Slides.Presentation srcPres = new Aspose.Slides.Presentation("source.pptx"))
            {
                using (Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation("target.pptx"))
                {
                    Aspose.Slides.ISlide sourceSlide = srcPres.Slides[0];
                    Aspose.Slides.ISlideCollection destSlides = destPres.Slides;
                    destSlides.InsertClone(destSlides.Count, sourceSlide);
                    destPres.Save("target_updated.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}