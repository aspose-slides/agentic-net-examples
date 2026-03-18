using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (Presentation pres = new Presentation())
            {
                // Define which slides are displayed during the slide show (slides 1 to 3)
                pres.SlideShowSettings.Slides = new SlidesRange { Start = 1, End = 3 };
                
                // Save the presentation
                pres.Save("SlideShowSequence.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}