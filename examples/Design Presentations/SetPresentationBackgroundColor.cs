using System;
using System.Drawing;

namespace PresentationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Iterate through all slides and set a solid color background
            for (int i = 0; i < pres.Slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = pres.Slides[i];
                // Use own background
                slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                // Set fill type to solid
                slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                // Set the solid fill color
                slide.Background.FillFormat.SolidFillColor.Color = Color.LightBlue;
            }

            // Save the presentation before exiting
            pres.Save("AllSlidesSolidBackground.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}