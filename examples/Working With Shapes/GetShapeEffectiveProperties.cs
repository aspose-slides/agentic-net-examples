using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx");

        // Get the first shape on the first slide
        Aspose.Slides.IShape shape = pres.Slides[0].Shapes[0];

        // Get effective fill format
        Aspose.Slides.IFillFormatEffectiveData effectiveFill = shape.FillFormat.GetEffective();

        // Output fill information
        Console.WriteLine("Effective Fill Type: " + effectiveFill.FillType);
        switch (effectiveFill.FillType)
        {
            case Aspose.Slides.FillType.Solid:
                Console.WriteLine("Solid Fill Color: " + effectiveFill.SolidFillColor);
                break;
            case Aspose.Slides.FillType.Pattern:
                Console.WriteLine("Pattern Style: " + effectiveFill.PatternFormat.PatternStyle);
                Console.WriteLine("Pattern Fore Color: " + effectiveFill.PatternFormat.ForeColor);
                Console.WriteLine("Pattern Back Color: " + effectiveFill.PatternFormat.BackColor);
                break;
            case Aspose.Slides.FillType.Gradient:
                Console.WriteLine("Gradient Direction: " + effectiveFill.GradientFormat.GradientDirection);
                Console.WriteLine("Gradient Stops Count: " + effectiveFill.GradientFormat.GradientStops.Count);
                break;
            case Aspose.Slides.FillType.Picture:
                Console.WriteLine("Picture Width: " + effectiveFill.PictureFillFormat.Picture.Image.Width);
                Console.WriteLine("Picture Height: " + effectiveFill.PictureFillFormat.Picture.Image.Height);
                break;
        }

        // Get effective line format
        Aspose.Slides.ILineFormatEffectiveData effectiveLine = shape.LineFormat.GetEffective();

        // Output line information
        Console.WriteLine("Effective Line Style: " + effectiveLine.Style);
        Console.WriteLine("Effective Line Width: " + effectiveLine.Width);
        Console.WriteLine("Effective Line Fill Type: " + effectiveLine.FillFormat.FillType);

        // Get effective effect format
        Aspose.Slides.IEffectFormatEffectiveData effectiveEffect = shape.EffectFormat.GetEffective();

        // Output shadow information if any
        if (effectiveEffect.PresetShadowEffect != null)
        {
            Console.WriteLine("Preset Shadow Color: " + effectiveEffect.PresetShadowEffect.ShadowColor);
        }
        if (effectiveEffect.OuterShadowEffect != null)
        {
            Console.WriteLine("Outer Shadow Color: " + effectiveEffect.OuterShadowEffect.ShadowColor);
        }
        if (effectiveEffect.InnerShadowEffect != null)
        {
            Console.WriteLine("Inner Shadow Color: " + effectiveEffect.InnerShadowEffect.ShadowColor);
        }

        // Save the presentation
        pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}