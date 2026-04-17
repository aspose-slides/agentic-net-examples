using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            // Define output file path
            string outputPath = "LineGradientEffectiveData.pptx";

            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Add a line shape
                IShape lineShape = slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

                // Configure gradient fill for the line
                lineShape.LineFormat.FillFormat.FillType = FillType.Gradient;
                lineShape.LineFormat.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
                lineShape.LineFormat.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;
                lineShape.LineFormat.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Purple);
                lineShape.LineFormat.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Red);

                // Retrieve effective line formatting data
                ILineFormatEffectiveData effectiveLine = lineShape.LineFormat.GetEffective();

                // Access effective line fill format
                ILineFillFormatEffectiveData effectiveFill = effectiveLine.FillFormat;

                // Ensure the fill type is gradient before accessing gradient data
                if (effectiveFill.FillType == FillType.Gradient)
                {
                    // Get effective gradient format
                    IGradientFormatEffectiveData effectiveGradient = effectiveFill.GradientFormat;

                    // Log gradient stops
                    for (int i = 0; i < effectiveGradient.GradientStops.Count; i++)
                    {
                        IGradientStopEffectiveData stop = effectiveGradient.GradientStops[i];
                        Console.WriteLine("Gradient Stop {0}: Position = {1}, Color = {2}", i, stop.Position, stop.Color);
                    }
                }

                // Save the presentation (required before exiting)
                try
                {
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
                catch (Exception ex)
                {
                    // Handle unsupported format or other save errors
                    Console.WriteLine("Error saving presentation: " + ex.Message);
                }
            }
        }
    }
}