using System;
using System.IO;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Ensure output directory exists
        string outputDir = "Output";
        if (!Directory.Exists(outputDir))
            Directory.CreateDirectory(outputDir);

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add an ellipse shape
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 100, 100, 200, 100);
        shape.Rotation = 30f; // Set rotation to 30 degrees

        // Apply outer shadow effect
        shape.EffectFormat.EnableOuterShadowEffect();
        shape.EffectFormat.OuterShadowEffect.BlurRadius = 5.0;
        shape.EffectFormat.OuterShadowEffect.Direction = 45;
        shape.EffectFormat.OuterShadowEffect.Distance = 5.0;
        shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.FromArgb(128, 0, 0, 0);

        // Save the presentation (required before exit)
        string pptxPath = Path.Combine(outputDir, "result.pptx");
        pres.Save(pptxPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Export the slide as SVG
        string svgPath = Path.Combine(outputDir, "slide.svg");
        using (FileStream svgStream = File.Create(svgPath))
        {
            slide.WriteAsSvg(svgStream);
        }
    }
}