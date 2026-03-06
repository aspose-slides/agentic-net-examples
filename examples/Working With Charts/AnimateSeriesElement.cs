using System;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output_series_animation.pptx";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Get the first slide and the first shape (assumed to be a chart)
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        Aspose.Slides.IShape shape = slide.Shapes[0];
        Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;

        // If the shape is not a chart, exit
        if (chart == null)
        {
            return;
        }

        // Add a fade effect to the whole chart
        slide.Timeline.MainSequence.AddEffect(
            chart,
            Aspose.Slides.Animation.EffectType.Fade,
            Aspose.Slides.Animation.EffectSubtype.None,
            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

        // Animate each series in the chart
        int seriesCount = chart.ChartData.Series.Count;
        for (int s = 0; s < seriesCount; s++)
        {
            ((Aspose.Slides.Animation.Sequence)slide.Timeline.MainSequence).AddEffect(
                chart,
                Aspose.Slides.Animation.EffectChartMajorGroupingType.BySeries,
                s,
                Aspose.Slides.Animation.EffectType.Appear,
                Aspose.Slides.Animation.EffectSubtype.None,
                Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);
        }

        // Animate each element within each series
        for (int s = 0; s < seriesCount; s++)
        {
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[s];
            int pointCount = series.DataPoints.Count;
            for (int p = 0; p < pointCount; p++)
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

        // Save the presentation with the applied animations
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}