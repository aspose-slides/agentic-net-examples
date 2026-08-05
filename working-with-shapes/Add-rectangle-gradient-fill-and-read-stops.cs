// -----------------------------------------------------------------------------
// Example: Add rectangle gradient fill and read stops using C#
//
// Description:
// Demonstrates how to add a rectangle shape with a linear gradient fill and
// read the effective gradient fill data, including angle and gradient stops,
// using Aspose.Slides for .NET. The example creates a presentation, saves it,
// and outputs gradient details to the console.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Rectangle, Gradient Fill, 
// Gradient Stops, Effective Fill Data, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding gradient-filled rectangles to PowerPoint slides.
// - Retrieve and inspect gradient fill properties programmatically.
// - Build .NET tools for PPTX generation and validation.
// - Integrate gradient fill handling into presentation workflows.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace GradientExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Add a rectangle shape
            IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 300, 200);

            // Apply gradient fill to the rectangle
            shape.FillFormat.FillType = FillType.Gradient;
            shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
            shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;
            shape.FillFormat.GradientFormat.GradientStops.Add(0f, PresetColor.Purple);
            shape.FillFormat.GradientFormat.GradientStops.Add(1f, PresetColor.Red);

            // Save the presentation
            string outputPath = "GradientRectangle.pptx";
            pres.Save(outputPath, SaveFormat.Pptx);

            // Retrieve effective fill format data
            IFillFormatEffectiveData effectiveFill = shape.FillFormat.GetEffective();

            // Ensure the fill type is gradient before accessing gradient data
            if (effectiveFill.FillType == FillType.Gradient)
            {
                IGradientFormatEffectiveData gradientEffective = effectiveFill.GradientFormat;

                // Read the linear gradient angle
                float angle = gradientEffective.LinearGradientAngle;
                Console.WriteLine("Linear Gradient Angle: " + angle);

                // Read gradient stops
                int stopsCount = gradientEffective.GradientStops.Count;
                Console.WriteLine("Gradient Stops Count: " + stopsCount);
                for (int i = 0; i < stopsCount; i++)
                {
                    IGradientStopEffectiveData stop = gradientEffective.GradientStops[i];
                    Console.WriteLine("Stop " + i + " - Position: " + stop.Position + ", Color: " + stop.Color);
                }
            }
            else
            {
                Console.WriteLine("The shape does not have a gradient fill.");
            }
        }
    }
}
