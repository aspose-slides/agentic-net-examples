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