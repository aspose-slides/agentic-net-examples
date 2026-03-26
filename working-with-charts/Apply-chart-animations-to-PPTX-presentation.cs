using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output_animated.pptx";

        // Load existing presentation if it exists, otherwise create a new one
        Presentation presentation;
        if (File.Exists(inputPath))
        {
            presentation = new Presentation(inputPath);
        }
        else
        {
            presentation = new Presentation();
            // Add a sample chart to the first slide
            ISlide slide0 = presentation.Slides[0];
            IChart chart0 = slide0.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
        }

        // Get the first slide and the first shape (assumed to be a chart)
        ISlide slide = presentation.Slides[0];
        IShape shape = slide.Shapes[0];
        IChart chart = shape as IChart;
        if (chart == null)
        {
            return;
        }

        // Add a fade effect to the whole chart
        slide.Timeline.MainSequence.AddEffect(
            chart,
            EffectType.Fade,
            EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

        // Animate each series in the chart
        int seriesCount = chart.ChartData.Series.Count;
        for (int s = 0; s < seriesCount; s++)
        {
            ((Sequence)slide.Timeline.MainSequence).AddEffect(
                chart,
                EffectChartMajorGroupingType.BySeries,
                s,
                EffectType.Appear,
                EffectSubtype.None,
                EffectTriggerType.AfterPrevious);
        }

        // Animate each data point within each series
        for (int s = 0; s < seriesCount; s++)
        {
            IChartSeries series = chart.ChartData.Series[s];
            int pointCount = series.DataPoints.Count;
            for (int p = 0; p < pointCount; p++)
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

        // Save the presentation with animations
        presentation.Save(outputPath, SaveFormat.Pptx);
    }
}