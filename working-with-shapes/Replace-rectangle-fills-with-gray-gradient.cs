using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add rectangle shapes
        Aspose.Slides.IShape rect1 = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);
        Aspose.Slides.IShape rect2 = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 300, 200, 150, 80);

        // Apply gradient fill to each rectangle
        ApplyGradient(rect1);
        ApplyGradient(rect2);

        // Save the presentation
        pres.Save("GradientRectangles.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }

    static void ApplyGradient(Aspose.Slides.IShape shape)
    {
        // Set gradient fill type
        shape.FillFormat.FillType = Aspose.Slides.FillType.Gradient;

        // Configure gradient shape and direction
        shape.FillFormat.GradientFormat.GradientShape = Aspose.Slides.GradientShape.Linear;
        shape.FillFormat.GradientFormat.GradientDirection = Aspose.Slides.GradientDirection.FromCorner2;

        // Add gradient stops: light gray to dark gray
        shape.FillFormat.GradientFormat.GradientStops.Add(0, Aspose.Slides.PresetColor.LightGray);
        shape.FillFormat.GradientFormat.GradientStops.Add(1, Aspose.Slides.PresetColor.DarkGray);
    }
}