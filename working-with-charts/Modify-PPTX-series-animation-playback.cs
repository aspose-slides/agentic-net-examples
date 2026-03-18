using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Paths to the input and output presentations
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Get the first slide and its first shape
                ISlide slide = presentation.Slides[0];
                IShape shape = slide.Shapes[0];

                // Cast the shape to a chart
                IChart chart = shape as IChart;
                if (chart == null)
                {
                    Console.WriteLine("No chart found on the first slide.");
                    return;
                }

                // Add a fade effect for the whole chart
                slide.Timeline.MainSequence.AddEffect(
                    chart,
                    EffectType.Fade,
                    EffectSubtype.None,
                    EffectTriggerType.AfterPrevious);

                // Animate each series of the chart
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

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}