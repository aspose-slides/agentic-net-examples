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