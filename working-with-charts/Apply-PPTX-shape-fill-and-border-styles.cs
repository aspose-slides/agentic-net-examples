using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Aspose.Slides.Presentation();
            var slide = presentation.Slides[0];
            var shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);

            // Apply solid fill with semi‑transparent red
            shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            shape.FillFormat.SolidFillColor.Color = System.Drawing.Color.FromArgb(128, System.Drawing.Color.Red);

            // Set line color and width
            shape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            shape.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;
            shape.LineFormat.Width = 3;

            // Enable outer shadow and set its color
            shape.EffectFormat.EnableOuterShadowEffect();
            shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = System.Drawing.Color.Gray;
            shape.EffectFormat.OuterShadowEffect.Distance = 5;

            // Enable glow effect and set its color and radius
            shape.EffectFormat.EnableGlowEffect();
            shape.EffectFormat.GlowEffect.Radius = 10;
            shape.EffectFormat.GlowEffect.Color.Color = System.Drawing.Color.Yellow;

            // Save the presentation
            presentation.Save("CustomShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}