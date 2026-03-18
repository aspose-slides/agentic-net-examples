using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        Aspose.Slides.Presentation presentation = null;
        string outputPath = "EffectiveShadowOutput.pptx";

        try
        {
            presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);
            shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            shape.FillFormat.SolidFillColor.Color = Color.Blue;

            // Enable and configure outer shadow
            shape.EffectFormat.EnableOuterShadowEffect();
            shape.EffectFormat.OuterShadowEffect.BlurRadius = 5.0;
            shape.EffectFormat.OuterShadowEffect.Distance = 3.0;
            shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.FromArgb(128, 0, 0, 0);

            // Retrieve effective outer shadow data
            Aspose.Slides.IEffectFormatEffectiveData effectiveEffect = shape.EffectFormat.GetEffective();
            Aspose.Slides.Effects.IOuterShadowEffectiveData outerShadow = effectiveEffect.OuterShadowEffect;

            Console.WriteLine("Outer Shadow BlurRadius: " + outerShadow.BlurRadius);
            Console.WriteLine("Outer Shadow Distance: " + outerShadow.Distance);
            Console.WriteLine("Outer Shadow Color: " + outerShadow.ShadowColor);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            if (presentation != null)
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
        }
    }
}