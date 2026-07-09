using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a circular (ellipse) shape
        Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 100, 100, 300, 300);

        // Apply radial gradient fill
        shape.FillFormat.FillType = Aspose.Slides.FillType.Gradient;
        shape.FillFormat.GradientFormat.GradientShape = Aspose.Slides.GradientShape.Radial;
        shape.FillFormat.GradientFormat.LinearGradientAngle = 90f; // Set angle to ninety degrees

        // Add three gradient stops (red, green, blue)
        shape.FillFormat.GradientFormat.GradientStops.Add(0, Aspose.Slides.PresetColor.Red);
        shape.FillFormat.GradientFormat.GradientStops.Add(50, Aspose.Slides.PresetColor.Green);
        shape.FillFormat.GradientFormat.GradientStops.Add(100, Aspose.Slides.PresetColor.Blue);

        // Save the presentation
        presentation.Save("RadialGradient.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation
        presentation.Dispose();
    }
}