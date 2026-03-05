using System;
using System.Drawing;

namespace BackgroundExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                // Set the background of the first slide to a solid blue color
                pres.Slides[0].Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                pres.Slides[0].Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                pres.Slides[0].Background.FillFormat.SolidFillColor.Color = Color.Blue;

                // Save the presentation to disk
                pres.Save("BackgroundColor_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}