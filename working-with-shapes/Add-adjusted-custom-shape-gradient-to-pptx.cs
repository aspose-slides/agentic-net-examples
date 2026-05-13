using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Get the first slide
        ISlide slide = presentation.Slides[0];

        // Add a rectangle auto shape at specific coordinates
        IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100f, 100f, 200f, 100f);

        // Access adjustment handles via GeometryShape
        GeometryShape geometryShape = autoShape as GeometryShape;
        if (geometryShape != null && geometryShape.Adjustments.Count > 0)
        {
            // Example: set the first adjustment value
            geometryShape.Adjustments[0].RawValue = 5000L;
        }

        // Apply a linear gradient fill
        autoShape.FillFormat.FillType = FillType.Gradient;
        autoShape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
        autoShape.FillFormat.GradientFormat.GradientStops.Add(0, Color.Blue);
        autoShape.FillFormat.GradientFormat.GradientStops.Add(100, Color.Orange);

        // Save the presentation
        presentation.Save("custom_shape.pptx", SaveFormat.Pptx);
    }
}