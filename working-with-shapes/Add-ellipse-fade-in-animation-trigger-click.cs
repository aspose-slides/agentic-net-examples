using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add an ellipse shape to the first slide
        Aspose.Slides.IShape ellipse = presentation.Slides[0].Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Ellipse, 100, 100, 200, 150);

        // Apply a fade‑in animation with OnClick trigger
        Aspose.Slides.Animation.IEffect fadeEffect = presentation.Slides[0].Timeline.MainSequence.AddEffect(
            ellipse,
            Aspose.Slides.Animation.EffectType.Fade,
            Aspose.Slides.Animation.EffectSubtype.None,
            Aspose.Slides.Animation.EffectTriggerType.OnClick);

        // Define output path
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "EllipseFadeIn.pptx");

        // Save the presentation with exception handling for unsupported formats
        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
    }
}