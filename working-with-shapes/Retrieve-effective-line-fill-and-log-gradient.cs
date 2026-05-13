using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Add a line shape
            IShape lineShape = slide.Shapes.AddAutoShape(ShapeType.Line, 100, 100, 400, 0);

            // Set gradient fill for the line
            lineShape.LineFormat.FillFormat.FillType = FillType.Gradient;
            lineShape.LineFormat.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
            lineShape.LineFormat.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;
            lineShape.LineFormat.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Purple);
            lineShape.LineFormat.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Red);

            // Retrieve effective line format data
            ILineFormatEffectiveData effectiveLineFormat = lineShape.LineFormat.GetEffective();

            // Log fill type
            Console.WriteLine("Line Fill Type: " + effectiveLineFormat.FillFormat.FillType);

            // If the fill type is gradient, log gradient details
            if (effectiveLineFormat.FillFormat.FillType == FillType.Gradient)
            {
                ILineFillFormatEffectiveData lineFillEff = effectiveLineFormat.FillFormat;
                IGradientFormatEffectiveData gradientEff = lineFillEff.GradientFormat;

                Console.WriteLine("Gradient Shape: " + gradientEff.GradientShape);
                Console.WriteLine("Gradient Direction: " + gradientEff.GradientDirection);
                Console.WriteLine("Gradient Stops Count: " + gradientEff.GradientStops.Count);

                foreach (IGradientStopEffectiveData stop in gradientEff.GradientStops)
                {
                    Console.WriteLine("Stop Position: " + stop.Position + ", Color: " + stop.Color);
                }
            }

            // Define output file path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "GradientLineExample.pptx");

            // Save the presentation
            pres.Save(outputPath, SaveFormat.Pptx);
        }
    }
}