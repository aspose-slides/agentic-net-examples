// -----------------------------------------------------------------------------
// Example: Add ellipse fade in animation trigger click using C#
//
// Description:
// Demonstrates how to add an ellipse shape to a slide and apply a fade‑in
// animation that is triggered by a mouse click, using C# and Aspose.Slides for
// .NET. The example creates a new presentation, inserts an ellipse, configures
// the animation, and saves the result as a PPTX file. This pattern can be used
// to automate PowerPoint presentation creation and animation setup in .NET
// applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Ellipse, Fade, Animation,
// Trigger, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding ellipse fade‑in animation with click trigger.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files with animated shapes in .NET.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add an ellipse shape to the first slide
        Aspose.Slides.IShape ellipse = presentation.Slides[0].Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Ellipse, 100, 100, 200, 150);

        // Apply a fade‑in animation with OnClick trigger
        Aspose.Slides.Animation.IEffect fadeEffect = presentation.Slides[0].Timeline.MainSequence.AddEffect(
            ellipse,
            Aspose.Slides.Animation.EffectType.Fade,
            Aspose.Slides.Animation.EffectSubtype.None,
            Aspose.Slides.Animation.EffectTriggerType.OnClick);

        // Define output path
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "EllipseFadeIn.pptx");

        // Save the presentation with exception handling for unsupported formats
        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
    }
}
