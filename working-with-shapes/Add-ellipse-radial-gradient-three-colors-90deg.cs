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
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a circular shape (ellipse)
            IShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 100, 100, 300, 300);

            // Set fill type to gradient
            shape.FillFormat.FillType = FillType.Gradient;

            // Configure gradient as radial
            shape.FillFormat.GradientFormat.GradientShape = GradientShape.Radial;

            // Set gradient angle to 90 degrees
            shape.FillFormat.GradientFormat.LinearGradientAngle = 90f;

            // Add three gradient stops
            shape.FillFormat.GradientFormat.GradientStops.Add(0, PresetColor.Red);
            shape.FillFormat.GradientFormat.GradientStops.Add(50, PresetColor.Green);
            shape.FillFormat.GradientFormat.GradientStops.Add(100, PresetColor.Blue);

            // Save the presentation
            try
            {
                presentation.Save("RadialGradient.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle format not supported or other save errors
                // Format not supported
            }

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}