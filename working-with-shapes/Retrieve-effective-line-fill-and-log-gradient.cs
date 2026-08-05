// -----------------------------------------------------------------------------
// Example: Retrieve effective line fill and log gradient using C#
//
// Description:
// Demonstrates how to create a line shape with a gradient fill, retrieve its
// effective line fill data, and log gradient details using C# and Aspose.Slides
// for .NET. The example shows the necessary presentation‑processing steps for
// PowerPoint files and saves the resulting presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Retrieve Effective Line Fill,
// Gradient Fill, Line Shape, Presentation Processing, Office Automation
//
// Use Cases:
// - Extract effective line fill properties from a shape.
// - Log gradient fill details for debugging or analysis.
// - Automate PowerPoint shape formatting validation.
// - Build .NET tools that generate or modify PPTX files with gradient lines.
// -----------------------------------------------------------------------------
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
