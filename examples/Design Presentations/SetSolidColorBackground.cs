using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Set a solid background color for each slide
        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            // Use own background
            presentation.Slides[i].Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            // Set fill type to solid
            presentation.Slides[i].Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            // Choose a solid color (e.g., LightGray)
            presentation.Slides[i].Background.FillFormat.SolidFillColor.Color = Color.LightGray;
        }

        // Save the presentation before exiting
        presentation.Save("AllSlidesSolidBackground.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}