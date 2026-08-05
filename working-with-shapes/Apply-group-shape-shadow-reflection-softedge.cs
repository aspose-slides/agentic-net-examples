// -----------------------------------------------------------------------------
// Example: Apply group shape shadow reflection softedge using C#
//
// Description:
// Demonstrates how to apply a preset shadow, reflection, and soft edge effects
// to a group shape using C# and Aspose.Slides for .NET. The example creates a
// new presentation, adds a group shape with sample child shapes, enables the
// visual effects, and saves the result as a PPTX file. This pattern helps
// developers automate visual styling of grouped objects in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Group Shape, Shadow,
// Reflection, Soft Edge, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate applying shadow, reflection, and soft edge effects to group shapes.
// - Build C# tools for enhancing visual appearance of PowerPoint presentations.
// - Generate or transform PPTX files with styled grouped objects in .NET applications.
// - Validate presentation styling workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Presentation presentation = new Presentation())
        {
            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add an empty group shape to the slide
            IGroupShape groupShape = slide.Shapes.AddGroupShape();

            // Add sample shapes inside the group (optional, just for visual effect)
            groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 100, 100);
            groupShape.Shapes.AddAutoShape(ShapeType.Ellipse, 120, 0, 100, 100);

            // Apply preset shadow effect
            groupShape.EffectFormat.EnablePresetShadowEffect();

            // Apply reflection effect
            groupShape.EffectFormat.EnableReflectionEffect();

            // Apply soft edge effect
            groupShape.EffectFormat.EnableSoftEdgeEffect();

            // Save the presentation (handle unsupported format)
            try
            {
                presentation.Save("GroupShapeEffects.pptx", SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
        }
    }
}
