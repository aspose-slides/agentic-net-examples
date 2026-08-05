// -----------------------------------------------------------------------------
// Example: Export animated chart as GIF for web using C#
//
// Description:
// Demonstrates how to export an animated chart as a GIF for web using C# and 
// Aspose.Slides for .NET. The example creates a presentation, adds a clustered 
// column chart, applies fade and appear animations to the chart, its series, 
// and individual data points, then saves the animation as a GIF file suitable 
// for web delivery. It also saves the original presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, Animated, Chart, GIF, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate export of animated charts as GIFs for web publishing.
// - Build C# tools for PowerPoint presentation processing with animation.
// - Generate or transform PPTX files with animated content in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Add a clustered column chart
        IChart chart = presentation.Slides[0].Shapes.AddChart(
            ChartType.ClusteredColumn, 50, 50, 500, 400);

        // Get the first slide
        ISlide slide = presentation.Slides[0];

        // Add a fade effect to the chart
        slide.Timeline.MainSequence.AddEffect(
            chart,
            EffectType.Fade,
            EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

        // Animate each series
        Int32 seriesCount = chart.ChartData.Series.Count;
        for (Int32 s = 0; s < seriesCount; s++)
        {
            ((Sequence)slide.Timeline.MainSequence).AddEffect(
                chart,
                EffectChartMajorGroupingType.BySeries,
                s,
                EffectType.Appear,
                EffectSubtype.None,
                EffectTriggerType.AfterPrevious);
        }

        // Animate each element in each series
        for (Int32 s = 0; s < seriesCount; s++)
        {
            IChartSeries series = chart.ChartData.Series[s];
            Int32 pointCount = series.DataPoints.Count;
            for (Int32 p = 0; p < pointCount; p++)
            {
                ((Sequence)slide.Timeline.MainSequence).AddEffect(
                    chart,
                    EffectChartMinorGroupingType.ByElementInSeries,
                    s,
                    p,
                    EffectType.Appear,
                    EffectSubtype.None,
                    EffectTriggerType.AfterPrevious);
            }
        }

        // Export the animated chart as GIF
        try
        {
            GifOptions gifOptions = new GifOptions();
            gifOptions.FrameSize = new Size(960, 720);
            gifOptions.DefaultDelay = 2000; // 2 seconds per frame
            gifOptions.TransitionFps = 35;   // smoother animation
            presentation.Save("AnimatedChart.gif", SaveFormat.Gif, gifOptions);
        }
        catch (Exception)
        {
            // Format not supported
        }

        // Save the presentation
        presentation.Save("AnimatedChart.pptx", SaveFormat.Pptx);
        presentation.Dispose();
    }
}
