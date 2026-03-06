using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Effects;

namespace CustomPresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a rectangle shape
            Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle,
                50,   // X position
                50,   // Y position
                300,  // Width
                200   // Height
            );

            // Set solid fill color
            shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            shape.FillFormat.SolidFillColor.Color = Color.FromArgb(255, 100, 150, 200);

            // Set line (border) style
            shape.LineFormat.Width = 5;
            shape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

            // Enable outer shadow effect
            shape.EffectFormat.EnableOuterShadowEffect();

            // Configure outer shadow properties
            Aspose.Slides.Effects.IOuterShadow outerShadow = shape.EffectFormat.OuterShadowEffect;
            outerShadow.BlurRadius = 5.0;               // Blur radius in points
            outerShadow.Direction = 45;                 // Direction in degrees
            outerShadow.Distance = 10.0;                // Distance in points
            outerShadow.ShadowColor.Color = Color.FromArgb(128, 0, 0, 0); // Semi‑transparent black

            // Save the presentation
            pres.Save("CustomShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            pres.Dispose();
        }
    }
}