using System;
using System.IO;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "GroupShapeShadow.pptx";

        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add an empty group shape to the slide
            Aspose.Slides.IGroupShape group = slide.Shapes.AddGroupShape();

            // Add a rectangle inside the group
            group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);

            // Add an ellipse inside the group
            group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 150, 150, 100, 100);

            // Enable outer shadow effect for the group shape
            group.EffectFormat.EnableOuterShadowEffect();

            // Set shadow offset (distance) to five points
            group.EffectFormat.OuterShadowEffect.Distance = 5;

            // Optional: configure additional shadow properties
            group.EffectFormat.OuterShadowEffect.BlurRadius = 3;
            group.EffectFormat.OuterShadowEffect.Direction = 45;
            group.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.Black;

            // Save the presentation
            pres.Save(outputPath, SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}