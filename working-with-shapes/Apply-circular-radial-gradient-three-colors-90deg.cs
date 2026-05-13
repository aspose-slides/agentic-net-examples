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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a circular shape (ellipse)
            Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Ellipse,
                100,   // X position
                100,   // Y position
                300,   // Width
                300);  // Height

            // Set fill type to gradient
            shape.FillFormat.FillType = Aspose.Slides.FillType.Gradient;

            // Configure gradient as radial
            shape.FillFormat.GradientFormat.GradientShape = Aspose.Slides.GradientShape.Radial;

            // Set gradient angle to 90 degrees
            shape.FillFormat.GradientFormat.LinearGradientAngle = 90f;

            // Add three gradient stops
            shape.FillFormat.GradientFormat.GradientStops.Add(0, Aspose.Slides.PresetColor.Purple);
            shape.FillFormat.GradientFormat.GradientStops.Add(50, Aspose.Slides.PresetColor.Red);
            shape.FillFormat.GradientFormat.GradientStops.Add(100, Aspose.Slides.PresetColor.Yellow);

            // Save the presentation
            try
            {
                presentation.Save("RadialGradient.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (System.NotSupportedException)
            {
                // Format not supported
            }
            finally
            {
                // Ensure resources are released
                presentation.Dispose();
            }
        }
    }
}