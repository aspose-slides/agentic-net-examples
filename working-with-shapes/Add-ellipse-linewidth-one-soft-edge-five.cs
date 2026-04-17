using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Effects;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add an ellipse shape
            Aspose.Slides.IAutoShape ellipse = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Ellipse, 100f, 100f, 200f, 150f);

            // Set the line width to one point
            ellipse.LineFormat.Width = 1f;

            // Create a soft edge effect with a radius of five points
            Aspose.Slides.Effects.EffectFactory effectFactory = new Aspose.Slides.Effects.EffectFactory();
            Aspose.Slides.Effects.ISoftEdge softEdge = effectFactory.CreateSoftEdge();
            softEdge.Radius = 5.0; // Radius is a double

            // Apply the soft edge effect to the ellipse
            ellipse.EffectFormat.SoftEdgeEffect = softEdge;

            // Save the presentation
            try
            {
                presentation.Save("EllipseWithSoftEdge.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception)
            {
                // Handle format not supported or other save errors
            }
        }
    }
}