using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace PresentationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                // Set the background of the first slide to solid white
                pres.Slides[0].Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                pres.Slides[0].Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                pres.Slides[0].Background.FillFormat.SolidFillColor.Color = Color.White;

                // Save the presentation
                pres.Save("WhiteBackground.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}