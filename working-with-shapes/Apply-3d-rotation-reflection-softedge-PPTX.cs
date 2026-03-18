using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                var shape = pres.Slides[0].Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 200);
                // Apply 3D rotation
                shape.ThreeDFormat.Camera.SetRotation(30, 20, 10);
                shape.ThreeDFormat.Material = Aspose.Slides.MaterialPresetType.Plastic;
                // Enable reflection effect
                shape.EffectFormat.EnableReflectionEffect();
                // Enable soft edge effect
                shape.EffectFormat.EnableSoftEdgeEffect();
                shape.EffectFormat.SoftEdgeEffect.Radius = 5;
                // Save the presentation
                pres.Save("ShapeEffects.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}