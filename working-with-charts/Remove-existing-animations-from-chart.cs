using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Presentation presentation = new Presentation(inputPath))
            {
                ISlide slide = presentation.Slides[0];
                IShape shape = slide.Shapes[0];
                IChart chart = shape as IChart;
                if (chart == null)
                {
                    Console.WriteLine("No chart found on the first slide.");
                    return;
                }

                // Remove existing animations
                ISequence mainSequence = slide.Timeline.MainSequence;
                mainSequence.Clear();

                // Add fade effect for the whole chart
                slide.Timeline.MainSequence.AddEffect(
                    chart,
                    EffectType.Fade,
                    EffectSubtype.None,
                    EffectTriggerType.AfterPrevious);

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

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}