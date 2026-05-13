using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RetrieveLineGradientFill
{
    class Program
    {
        static void Main()
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Add a line shape
                Aspose.Slides.IShape lineShape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Line, 50, 150, 300, 0);

                // Apply gradient fill to the line
                lineShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Gradient;
                lineShape.LineFormat.FillFormat.GradientFormat.GradientShape = Aspose.Slides.GradientShape.Linear;
                lineShape.LineFormat.FillFormat.GradientFormat.GradientDirection = Aspose.Slides.GradientDirection.FromCorner2;
                lineShape.LineFormat.FillFormat.GradientFormat.GradientStops.Add(0f, Aspose.Slides.PresetColor.Purple);
                lineShape.LineFormat.FillFormat.GradientFormat.GradientStops.Add(1f, Aspose.Slides.PresetColor.Red);

                // Retrieve effective line fill data
                Aspose.Slides.ILineFormatEffectiveData effectiveLineFormat = lineShape.LineFormat.GetEffective();
                Aspose.Slides.ILineFillFormatEffectiveData effectiveFill = effectiveLineFormat.FillFormat;
                Aspose.Slides.IGradientFormatEffectiveData effectiveGradient = effectiveFill.GradientFormat;

                // Log gradient stops
                Console.WriteLine("Effective Gradient Stops:");
                for (int i = 0; i < effectiveGradient.GradientStops.Count; i++)
                {
                    Aspose.Slides.IGradientStopEffectiveData stop = effectiveGradient.GradientStops[i];
                    Console.WriteLine("Stop {0}: Position = {1}, Color = {2}", i, stop.Position, stop.Color);
                }

                // Save the presentation
                string outputPath = "LineGradientEffectiveData.pptx";
                try
                {
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
                catch (Exception ex)
                {
                    // If the format is not supported, handle accordingly
                    // Format not supported
                    Console.WriteLine("Error saving presentation: " + ex.Message);
                }
            }
        }
    }
}