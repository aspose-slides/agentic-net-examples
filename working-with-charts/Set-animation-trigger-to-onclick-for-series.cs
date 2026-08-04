// -----------------------------------------------------------------------------
// Example: Set animation trigger to onclick for series using C#
//
// Description:
// Demonstrates how to set an OnClick animation trigger for each series in a
// chart using C# and Aspose.Slides for .NET. The example creates a presentation,
// adds a clustered column chart, applies a fade effect to the whole chart, and
// then animates each series individually with an appear effect triggered on
// click. This pattern can be used to automate PPTX workflows involving chart
// animations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Animation, Trigger, OnClick, Series, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting OnClick animation triggers for chart series.
// - Build C# tools for PowerPoint chart animation processing.
// - Generate or modify PPTX files with custom chart animations in .NET applications.
// - Validate presentation animation workflows before publishing.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

        // Optional: add a fade effect to the whole chart triggered on click
        slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

        // Get the number of series in the chart
        int seriesCount = chart.ChartData.Series.Count;

        // Animate each series with an OnClick trigger
        for (int s = 0; s < seriesCount; s++)
        {
            ((Sequence)slide.Timeline.MainSequence).AddEffect(
                chart,
                EffectChartMajorGroupingType.BySeries,
                s,
                EffectType.Appear,
                EffectSubtype.None,
                EffectTriggerType.OnClick);
        }

        // Save the presentation
        presentation.Save("ChartSeriesOnClick.pptx", SaveFormat.Pptx);
    }
}
