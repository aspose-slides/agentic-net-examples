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

        // Add a rectangle shape
        Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 200);

        // Apply gradient fill to the rectangle
        shape.FillFormat.FillType = Aspose.Slides.FillType.Gradient;
        shape.FillFormat.GradientFormat.GradientShape = Aspose.Slides.GradientShape.Linear;
        shape.FillFormat.GradientFormat.GradientDirection = Aspose.Slides.GradientDirection.FromCorner2;
        shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, Aspose.Slides.PresetColor.Purple);
        shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, Aspose.Slides.PresetColor.Red);

        // Retrieve effective fill format data
        Aspose.Slides.IFillFormatEffectiveData effectiveFill = shape.FillFormat.GetEffective();

        // Access effective gradient format
        Aspose.Slides.IGradientFormatEffectiveData gradientEffective = effectiveFill.GradientFormat;

        // Read effective gradient properties
        Aspose.Slides.GradientDirection direction = gradientEffective.GradientDirection;
        Aspose.Slides.GradientShape gradientShape = gradientEffective.GradientShape;
        float angle = gradientEffective.LinearGradientAngle;
        int stopsCount = gradientEffective.GradientStops.Count;

        // Output effective gradient information
        Console.WriteLine("Effective Gradient Direction: " + direction);
        Console.WriteLine("Effective Gradient Shape: " + gradientShape);
        Console.WriteLine("Effective Linear Gradient Angle: " + angle);
        Console.WriteLine("Effective Gradient Stops Count: " + stopsCount);
        for (int i = 0; i < stopsCount; i++)
        {
            Aspose.Slides.IGradientStopEffectiveData stop = gradientEffective.GradientStops[i];
            Console.WriteLine("Stop " + i + ": Position=" + stop.Position + ", Color=" + stop.Color);
        }

        // Save the presentation
        presentation.Save("GradientRectangle.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}