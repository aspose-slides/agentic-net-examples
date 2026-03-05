using System;

namespace SoftEdgeExample
{
    class Program
    {
        static void Main()
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide in the presentation
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape to the slide
            Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, // Shape type
                50,  // X position
                50,  // Y position
                200, // Width
                100  // Height
            );

            // Enable the soft edge effect for the shape
            shape.EffectFormat.EnableSoftEdgeEffect();

            // Set the radius of the soft edge blur
            shape.EffectFormat.SoftEdgeEffect.Radius = 5.0;

            // Save the presentation to a file
            presentation.Save("SoftEdgeShape_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}