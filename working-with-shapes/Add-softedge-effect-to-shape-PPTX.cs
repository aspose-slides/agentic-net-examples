using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Effects;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Aspose.Slides.Presentation();
            var slide = presentation.Slides[0];
            var shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);
            // Enable soft edge effect
            shape.EffectFormat.EnableSoftEdgeEffect();
            // Create and configure soft edge effect
            var effectFactory = new Aspose.Slides.Effects.EffectFactory();
            var softEdge = effectFactory.CreateSoftEdge();
            softEdge.Radius = 5.0; // subtle blur radius
            shape.EffectFormat.SoftEdgeEffect = softEdge;
            // Save the presentation
            presentation.Save("SoftEdgeEffect.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}