using System;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Set background fill to a solid brush (color)
        slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        slide.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightBlue;

        // Save the presentation in PPT format
        presentation.Save("SetBrushProperties_out.ppt", Aspose.Slides.Export.SaveFormat.Ppt);
    }
}