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
            using (Presentation presentation = new Presentation())
            {
                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add an ellipse shape
                IAutoShape ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 100f, 100f, 200f, 150f);

                // Set line width to 1 point
                ellipse.LineFormat.Width = 1f;

                // Enable soft edge effect and set radius to 5 points
                ellipse.EffectFormat.EnableSoftEdgeEffect();
                ellipse.EffectFormat.SoftEdgeEffect.Radius = 5.0;

                // Save the presentation
                presentation.Save("EllipseSoftEdge.pptx", SaveFormat.Pptx);
            }
        }
    }
}