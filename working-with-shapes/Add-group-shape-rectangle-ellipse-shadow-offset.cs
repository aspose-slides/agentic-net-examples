using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Add a group shape to the slide
            IGroupShape group = slide.Shapes.AddGroupShape();

            // Add a rectangle inside the group
            group.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

            // Add an ellipse inside the group
            group.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 150, 100, 100);

            // Enable outer shadow effect for the group shape
            group.EffectFormat.EnableOuterShadowEffect();

            // Set the shadow offset (distance) to five points
            group.EffectFormat.OuterShadowEffect.Distance = 5.0;

            // Save the presentation
            string outputPath = "GroupShapeShadow.pptx";
            pres.Save(outputPath, SaveFormat.Pptx);

            // Dispose the presentation
            pres.Dispose();
        }
    }
}