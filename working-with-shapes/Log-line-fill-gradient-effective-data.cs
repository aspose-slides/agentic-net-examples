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
            Presentation pres = new Presentation();

            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Add a line shape to the slide
            IShape lineShape = slide.Shapes.AddAutoShape(ShapeType.Line, 100, 100, 400, 0);

            // Set the line fill to a gradient
            lineShape.LineFormat.FillFormat.FillType = FillType.Gradient;
            lineShape.LineFormat.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
            lineShape.LineFormat.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;
            lineShape.LineFormat.FillFormat.GradientFormat.GradientStops.Add(0, PresetColor.Purple);
            lineShape.LineFormat.FillFormat.GradientFormat.GradientStops.Add(1, PresetColor.Red);

            // Retrieve the effective line fill format
            ILineFormatEffectiveData effectiveLineFormat = lineShape.LineFormat.GetEffective();
            ILineFillFormatEffectiveData effectiveFill = effectiveLineFormat.FillFormat;

            Console.WriteLine("Effective line fill type: " + effectiveFill.FillType);
            if (effectiveFill.FillType == FillType.Gradient)
            {
                IGradientFormatEffectiveData gradient = effectiveFill.GradientFormat;
                Console.WriteLine("Gradient shape: " + gradient.GradientShape);
                Console.WriteLine("Gradient direction: " + gradient.GradientDirection);
                Console.WriteLine("Gradient stops count: " + gradient.GradientStops.Count);
                foreach (IGradientStopEffectiveData stop in gradient.GradientStops)
                {
                    Console.WriteLine("Offset: " + stop.Position + ", Color: " + stop.Color);
                }
            }

            // Save the presentation
            string outputPath = "LineGradientEffective.pptx";
            pres.Save(outputPath, SaveFormat.Pptx);
        }
    }
}