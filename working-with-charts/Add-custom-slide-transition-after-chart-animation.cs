// -----------------------------------------------------------------------------
// Example: Add custom slide transition after chart animation using C#
//
// Description:
// Demonstrates how to add a custom slide transition that starts after a chart
// animation completes using C# and Aspose.Slides for .NET. The example creates a
// presentation, inserts a clustered column chart, applies fade and appear
// animations to the chart series, and configures a slide transition that
// triggers immediately after the chart animation finishes.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Custom, Slide, Transition,
// After, Chart, Animation, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a slide transition that follows chart animations.
// - Build C# tools for advanced PowerPoint animation sequencing.
// - Generate or modify PPTX files with coordinated chart animations and
//   transitions in .NET applications.
// - Validate presentation workflows involving chart animations before
//   publishing or integration.
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

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50, 50, 400, 300);

        // Add an initial fade effect to the chart
        slide.Timeline.MainSequence.AddEffect(
            chart,
            Aspose.Slides.Animation.EffectType.Fade,
            Aspose.Slides.Animation.EffectSubtype.None,
            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

        // Cast the main sequence to a Sequence to add series animations
        Aspose.Slides.Animation.Sequence seq = (Aspose.Slides.Animation.Sequence)slide.Timeline.MainSequence;

        // Animate chart by series (example with five series)
        seq.AddEffect(
            chart,
            Aspose.Slides.Animation.EffectChartMajorGroupingType.BySeries,
            0,
            Aspose.Slides.Animation.EffectType.Appear,
            Aspose.Slides.Animation.EffectSubtype.None,
            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);
        seq.AddEffect(
            chart,
            Aspose.Slides.Animation.EffectChartMajorGroupingType.BySeries,
            1,
            Aspose.Slides.Animation.EffectType.Appear,
            Aspose.Slides.Animation.EffectSubtype.None,
            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);
        seq.AddEffect(
            chart,
            Aspose.Slides.Animation.EffectChartMajorGroupingType.BySeries,
            2,
            Aspose.Slides.Animation.EffectType.Appear,
            Aspose.Slides.Animation.EffectSubtype.None,
            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);
        seq.AddEffect(
            chart,
            Aspose.Slides.Animation.EffectChartMajorGroupingType.BySeries,
            3,
            Aspose.Slides.Animation.EffectType.Appear,
            Aspose.Slides.Animation.EffectSubtype.None,
            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);
        seq.AddEffect(
            chart,
            Aspose.Slides.Animation.EffectChartMajorGroupingType.BySeries,
            4,
            Aspose.Slides.Animation.EffectType.Appear,
            Aspose.Slides.Animation.EffectSubtype.None,
            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

        // Set a custom slide transition that will trigger after the chart animation finishes
        slide.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
        slide.SlideShowTransition.AdvanceAfter = true;
        slide.SlideShowTransition.AdvanceAfterTime = 0; // Immediate transition after animation

        // Save the presentation
        presentation.Save("AnimatedChartWithTransition.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
