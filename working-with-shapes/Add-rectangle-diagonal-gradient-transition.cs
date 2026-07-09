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
        Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 400, 200);

        // Apply diagonal gradient from top‑left to bottom‑right
        shape.FillFormat.FillType = Aspose.Slides.FillType.Gradient;
        shape.FillFormat.GradientFormat.GradientShape = Aspose.Slides.GradientShape.Linear;
        shape.FillFormat.GradientFormat.GradientDirection = Aspose.Slides.GradientDirection.FromCorner1;
        shape.FillFormat.GradientFormat.GradientStops.Add(0, Aspose.Slides.PresetColor.Purple);
        shape.FillFormat.GradientFormat.GradientStops.Add(100, Aspose.Slides.PresetColor.Red);

        // Verify gradient properties
        Aspose.Slides.IFillFormatEffectiveData effectiveFill = shape.FillFormat.GetEffective();
        Aspose.Slides.IGradientFormatEffectiveData effectiveGradient = effectiveFill.GradientFormat;
        Console.WriteLine("Gradient Shape: " + effectiveGradient.GradientShape);
        Console.WriteLine("Gradient Direction: " + effectiveGradient.GradientDirection);

        // Save the presentation
        try
        {
            presentation.Save("GradientRectangle.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }
    }
}