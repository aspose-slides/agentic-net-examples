using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var pres = new Aspose.Slides.Presentation();
            for (var i = 0; i < pres.Slides.Count; i++)
            {
                var slide = pres.Slides[i];
                slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                slide.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.White;
            }
            pres.Save("WhiteBackgroundPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}