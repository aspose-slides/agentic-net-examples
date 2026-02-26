using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Paths for input (if needed) and output
        string outputPath = "AnimatedChart_out.pptx";

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a chart (Clustered Column) with sample data
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 600f, 400f);

        // Add a fade effect to the whole chart
        slide.Timeline.MainSequence.AddEffect(
            chart,
            EffectType.Fade,
            EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

        // Animate each series
        System.Int32 seriesCount = chart.ChartData.Series.Count;
        for (System.Int32 s = 0; s < seriesCount; s++)
        {
            ((Aspose.Slides.Animation.Sequence)slide.Timeline.MainSequence).AddEffect(
                chart,
                EffectChartMajorGroupingType.BySeries,
                s,
                EffectType.Appear,
                EffectSubtype.None,
                EffectTriggerType.AfterPrevious);
        }

        // Animate each element within each series
        for (System.Int32 s = 0; s < seriesCount; s++)
        {
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[s];
            System.Int32 pointCount = series.DataPoints.Count;
            for (System.Int32 p = 0; p < pointCount; p++)
            {
                ((Aspose.Slides.Animation.Sequence)slide.Timeline.MainSequence).AddEffect(
                    chart,
                    EffectChartMinorGroupingType.ByElementInSeries,
                    s,
                    p,
                    EffectType.Appear,
                    EffectSubtype.None,
                    EffectTriggerType.AfterPrevious);
            }
        }

        // Save the presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}