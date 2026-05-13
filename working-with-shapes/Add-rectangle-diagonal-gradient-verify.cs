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

        // Add a rectangle shape
        Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 200);

        // Set fill type to gradient
        shape.FillFormat.FillType = Aspose.Slides.FillType.Gradient;

        // Configure gradient format
        shape.FillFormat.GradientFormat.GradientShape = Aspose.Slides.GradientShape.Linear;
        shape.FillFormat.GradientFormat.GradientDirection = Aspose.Slides.GradientDirection.FromCorner1;

        // Add gradient stops (purple at start, red at end)
        shape.FillFormat.GradientFormat.GradientStops.Add(0f, Aspose.Slides.PresetColor.Purple);
        shape.FillFormat.GradientFormat.GradientStops.Add(1f, Aspose.Slides.PresetColor.Red);

        // Verify gradient stops by reading effective fill format
        Aspose.Slides.IFillFormatEffectiveData effectiveFill = shape.FillFormat.GetEffective();
        Aspose.Slides.IGradientFormatEffectiveData effectiveGradient = effectiveFill.GradientFormat;
        Console.WriteLine("Gradient direction: " + effectiveGradient.GradientDirection);
        Console.WriteLine("Number of gradient stops: " + effectiveGradient.GradientStops.Count);
        foreach (Aspose.Slides.IGradientStopEffectiveData stop in effectiveGradient.GradientStops)
        {
            Console.WriteLine("Stop position: " + stop.Position + ", Color: " + stop.Color);
        }

        // Save the presentation
        try
        {
            pres.Save("RectangleDiagonalGradient.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        finally
        {
            pres.Dispose();
        }
    }
}