using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Set slide size to widescreen 16:9 with EnsureFit scaling
        presentation.SlideSize.SetSize(Aspose.Slides.SlideSizeType.OnScreen16x9, Aspose.Slides.SlideSizeScaleType.EnsureFit);

        // Change background of the first slide to blue
        presentation.Slides[0].Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        presentation.Slides[0].Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        presentation.Slides[0].Background.FillFormat.SolidFillColor.Color = Color.Blue;

        // Save the presentation
        string outputPath = "WidescreenPresentation.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}