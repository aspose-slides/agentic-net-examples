using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the presentation from a file
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx");

        // Access the first shape on the first slide
        Aspose.Slides.IShape shape = pres.Slides[0].Shapes[0];

        // Retrieve effective fill formatting data
        Aspose.Slides.IFillFormatEffectiveData effectiveFill = shape.FillFormat.GetEffective();
        Console.WriteLine("Effective Fill Type: " + effectiveFill.FillType);
        if (effectiveFill.FillType == FillType.Solid)
        {
            Console.WriteLine("Effective Fill Color: " + effectiveFill.SolidFillColor);
        }

        // Retrieve effective line formatting data
        Aspose.Slides.ILineFormatEffectiveData effectiveLine = shape.LineFormat.GetEffective();
        Console.WriteLine("Effective Line Style: " + effectiveLine.Style);
        Console.WriteLine("Effective Line Width: " + effectiveLine.Width);
        Console.WriteLine("Effective Line Fill Type: " + effectiveLine.FillFormat.FillType);

        // Retrieve effective effect formatting data (shadow information)
        Aspose.Slides.IEffectFormatEffectiveData effectiveEffect = shape.EffectFormat.GetEffective();
        if (effectiveEffect.OuterShadowEffect != null)
        {
            Console.WriteLine("Outer Shadow Color: " + effectiveEffect.OuterShadowEffect.ShadowColor);
        }
        if (effectiveEffect.InnerShadowEffect != null)
        {
            Console.WriteLine("Inner Shadow Color: " + effectiveEffect.InnerShadowEffect.ShadowColor);
        }

        // Save the presentation before exiting
        pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        pres.Dispose();
    }
}