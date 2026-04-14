using System;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
                {
                    // Get the first slide
                    Aspose.Slides.ISlide slide = presentation.Slides[0];

                    // Add an empty group shape (parameterless overload)
                    Aspose.Slides.IGroupShape groupShape = slide.Shapes.AddGroupShape();

                    // Add some shapes inside the group to visualize the effects
                    groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 0, 0, 100, 100);
                    groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 120, 0, 100, 100);

                    // Apply preset shadow, reflection, and soft edge effects
                    Aspose.Slides.IEffectFormat effectFormat = groupShape.EffectFormat;
                    effectFormat.EnablePresetShadowEffect();
                    effectFormat.EnableReflectionEffect();
                    effectFormat.EnableSoftEdgeEffect();

                    // Save the presentation
                    presentation.Save("GroupShapeEffects_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle errors such as unsupported formats
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}