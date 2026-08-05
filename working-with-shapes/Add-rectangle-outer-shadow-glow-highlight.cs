// -----------------------------------------------------------------------------
// Example: Add rectangle outer shadow glow highlight using C#
//
// Description:
// Demonstrates how to add a rectangle shape with an outer shadow and glow
// effect using C# and Aspose.Slides for .NET. The example creates a new
// presentation, inserts a rectangle, configures its fill, outer shadow, and
// glow, and saves the result as a PPTX file. This pattern can be used to
// automate visual enhancements in PowerPoint presentations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Rectangle, Outer Shadow, Glow,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Apply outer shadow and glow effects to shapes programmatically.
// - Build C# tools for enhancing PowerPoint visual elements.
// - Generate or modify PPTX files with styled shapes in .NET applications.
// - Automate design consistency checks for presentation assets.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Get the first slide
        ISlide slide = presentation.Slides[0];

        // Add a rectangle shape
        IAutoShape rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 150);

        // Set fill color
        rectangle.FillFormat.FillType = FillType.Solid;
        rectangle.FillFormat.SolidFillColor.Color = Color.FromArgb(255, 255, 255, 200); // Light yellow

        // Enable and configure outer shadow effect
        rectangle.EffectFormat.EnableOuterShadowEffect();
        rectangle.EffectFormat.OuterShadowEffect.BlurRadius = 5.0;
        rectangle.EffectFormat.OuterShadowEffect.Direction = 45;
        rectangle.EffectFormat.OuterShadowEffect.Distance = 4.0;
        rectangle.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.FromArgb(128, 0, 0, 0); // Semi‑transparent black

        // Enable and configure glow effect
        rectangle.EffectFormat.EnableGlowEffect();
        rectangle.EffectFormat.GlowEffect.Radius = 8.0;
        rectangle.EffectFormat.GlowEffect.Color.Color = Color.FromArgb(255, 255, 215, 0); // Gold

        // Save the presentation
        string outputPath = "OuterShadowGlow.pptx";
        try
        {
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other save errors
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
    }
}
