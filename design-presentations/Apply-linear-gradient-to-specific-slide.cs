using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Set the slide background to a gradient
        slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Gradient;

        // Set a custom gradient angle (in degrees)
        slide.Background.FillFormat.GradientFormat.LinearGradientAngle = 45f;

        // Define gradient colors
        slide.Background.FillFormat.GradientFormat.GradientStops.Add(0.0f, Aspose.Slides.PresetColor.Purple);
        slide.Background.FillFormat.GradientFormat.GradientStops.Add(1.0f, Aspose.Slides.PresetColor.Red);

        // Save the presentation
        string outputPath = "GradientBackground.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}