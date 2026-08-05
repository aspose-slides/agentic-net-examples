// -----------------------------------------------------------------------------
// Example: Add rectangle diagonal gradient verify using C#
//
// Description:
// Demonstrates how to add a rectangle shape with a diagonal gradient fill,
// then reads back the effective fill data to verify the gradient direction and
// stops using C# and Aspose.Slides for .NET. The example creates a presentation,
// configures the gradient, outputs verification details to the console, and
// saves the file as a PPTX.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Rectangle, Diagonal, Gradient,
// Verify, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding and verifying rectangle diagonal gradients.
// - Build C# utilities for PowerPoint presentation processing.
// - Generate or transform PPTX files with gradient fills in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation pres = new Presentation();

        // Get the first slide
        ISlide slide = pres.Slides[0];

        // Add a rectangle shape
        IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);

        // Set fill type to gradient
        shape.FillFormat.FillType = FillType.Gradient;

        // Configure gradient format
        shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
        shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner1;

        // Add gradient stops (purple at start, red at end)
        shape.FillFormat.GradientFormat.GradientStops.Add(0f, PresetColor.Purple);
        shape.FillFormat.GradientFormat.GradientStops.Add(1f, PresetColor.Red);

        // Verify gradient stops by reading effective fill format
        IFillFormatEffectiveData effectiveFill = shape.FillFormat.GetEffective();
        IGradientFormatEffectiveData effectiveGradient = effectiveFill.GradientFormat;
        Console.WriteLine("Gradient direction: " + effectiveGradient.GradientDirection);
        Console.WriteLine("Number of gradient stops: " + effectiveGradient.GradientStops.Count);
        foreach (IGradientStopEffectiveData stop in effectiveGradient.GradientStops)
        {
            Console.WriteLine("Stop position: " + stop.Position + ", Color: " + stop.Color);
        }

        // Save the presentation
        try
        {
            pres.Save("RectangleDiagonalGradient.pptx", SaveFormat.Pptx);
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
