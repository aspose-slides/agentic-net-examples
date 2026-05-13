using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Presentation presentation = new Presentation())
        {
            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add an empty group shape to the slide
            IGroupShape groupShape = slide.Shapes.AddGroupShape();

            // Add sample shapes inside the group (optional, just for visual effect)
            groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 100, 100);
            groupShape.Shapes.AddAutoShape(ShapeType.Ellipse, 120, 0, 100, 100);

            // Apply preset shadow effect
            groupShape.EffectFormat.EnablePresetShadowEffect();

            // Apply reflection effect
            groupShape.EffectFormat.EnableReflectionEffect();

            // Apply soft edge effect
            groupShape.EffectFormat.EnableSoftEdgeEffect();

            // Save the presentation (handle unsupported format)
            try
            {
                presentation.Save("GroupShapeEffects.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
        }
    }
}