using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            using (var pres = new Aspose.Slides.Presentation())
            {
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    var bg = pres.Slides[i].Background;
                    bg.Type = Aspose.Slides.BackgroundType.OwnBackground;
                    bg.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    bg.FillFormat.SolidFillColor.Color = Color.LightBlue;
                }

                pres.Save("UniformBackground.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}