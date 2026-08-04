// -----------------------------------------------------------------------------
// Example: Enable 3D rotation animation on chart using C#
//
// Description:
// Demonstrates how to enable 3D rotation animation on chart using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Enable, Rotation, Animation, 
// Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate enable 3D rotation animation on chart.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a clustered column chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 450f, 300f);

        // Set 3‑D rotation (rotate 45 degrees around Y‑axis)
        chart.Rotation3D.RotationY = 45;

        // Add an animation effect that plays after the previous (on slide show start)
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        slide.Timeline.MainSequence.AddEffect(
            chart,
            Aspose.Slides.Animation.EffectType.Appear,
            Aspose.Slides.Animation.EffectSubtype.None,
            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

        // Save the presentation
        presentation.Save("3DRotationAnimation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
