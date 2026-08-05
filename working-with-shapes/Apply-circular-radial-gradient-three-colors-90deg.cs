// -----------------------------------------------------------------------------
// Example: Apply circular radial gradient three colors 90deg using C#
//
// Description:
// Demonstrates how to apply a circular radial gradient with three colors at a
// 90-degree angle using C# and Aspose.Slides for .NET. The example shows the
// required presentation-processing steps for PowerPoint files and produces the
// requested output in a standalone console application. Developers can use this
// pattern to automate PPTX workflows, validate results, or integrate presentation
// logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Circular, Radial,
// Gradient, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate applying a circular radial gradient with three colors at 90°.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
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
