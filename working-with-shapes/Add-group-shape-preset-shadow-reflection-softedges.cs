using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Presentation pres = new Presentation())
        {
            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Add an empty group shape to the slide
            IGroupShape groupShape = slide.Shapes.AddGroupShape();

            // Add some shapes inside the group
            groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
            groupShape.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 150, 100, 100);

            // Apply a preset shadow effect
            groupShape.EffectFormat.EnablePresetShadowEffect();

            // Apply a reflection effect and set its distance
            groupShape.EffectFormat.EnableReflectionEffect();
            groupShape.EffectFormat.ReflectionEffect.Distance = 5.0;

            // Apply a soft edge effect and set its radius
            groupShape.EffectFormat.EnableSoftEdgeEffect();
            groupShape.EffectFormat.SoftEdgeEffect.Radius = 4.0;

            // Save the presentation before exiting
            pres.Save("GroupShapeEffects.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}