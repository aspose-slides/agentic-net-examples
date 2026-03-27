using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;

class Program
{
    static void Main(string[] args)
    {
        // Output file path
        string outputPath = "AnimatedChart.pptx";

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.IShape shape = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);
        Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;
        if (chart == null) return;

        // Add a fade effect to the whole chart
        slide.Timeline.MainSequence.AddEffect(
            chart,
            Aspose.Slides.Animation.EffectType.Fade,
            Aspose.Slides.Animation.EffectSubtype.None,
            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

        // Animate each series
        System.Int32 seriesCount = chart.ChartData.Series.Count;
        for (System.Int32 s = 0; s < seriesCount; s++)
        {
            ((Aspose.Slides.Animation.Sequence)slide.Timeline.MainSequence).AddEffect(
                chart,
                Aspose.Slides.Animation.EffectChartMajorGroupingType.BySeries,
                s,
                Aspose.Slides.Animation.EffectType.Appear,
                Aspose.Slides.Animation.EffectSubtype.None,
                Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);
        }

        // Animate each data point within each series
        for (System.Int32 s = 0; s < seriesCount; s++)
        {
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[s];
            System.Int32 pointCount = series.DataPoints.Count;
            for (System.Int32 p = 0; p < pointCount; p++)
            {
                ((Aspose.Slides.Animation.Sequence)slide.Timeline.MainSequence).AddEffect(
                    chart,
                    Aspose.Slides.Animation.EffectChartMinorGroupingType.ByElementInSeries,
                    s,
                    p,
                    Aspose.Slides.Animation.EffectType.Appear,
                    Aspose.Slides.Animation.EffectSubtype.None,
                    Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);
            }
        }

        // Save the presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}