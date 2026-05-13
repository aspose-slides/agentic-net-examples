using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a group shape to the slide
        Aspose.Slides.IGroupShape group = slide.Shapes.AddGroupShape();

        // Add a rectangle inside the group
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);

        // Add an ellipse inside the group
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 150, 250, 150, 100);

        // Apply outer shadow effect to the group with an offset (distance) of 5 points
        group.EffectFormat.EnableOuterShadowEffect();
        group.EffectFormat.OuterShadowEffect.Distance = 5;

        // Save the presentation
        string outPath = Path.Combine(Directory.GetCurrentDirectory(), "GroupShapeShadow.pptx");
        pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}