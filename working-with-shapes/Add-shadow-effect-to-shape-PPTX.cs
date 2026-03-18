using Aspose.Slides.Export;
using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Aspose.Slides.Presentation();
            var slide = presentation.Slides[0];
            var shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);
            shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            shape.FillFormat.SolidFillColor.Color = Color.LightBlue;

            // Enable and configure outer shadow
            shape.EffectFormat.EnableOuterShadowEffect();
            var outerShadow = shape.EffectFormat.OuterShadowEffect;
            outerShadow.BlurRadius = 5;
            outerShadow.Distance = 4;
            outerShadow.Direction = 45;
            outerShadow.ShadowColor.Color = Color.FromArgb(128, Color.Black);

            // Save the presentation
            presentation.Save("ShadowEffect.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}