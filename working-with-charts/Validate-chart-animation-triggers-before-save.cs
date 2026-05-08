using System;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

namespace ChartAnimationValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

                // Access the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Add a clustered column chart
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    100f, 100f, 500f, 350f) as Aspose.Slides.Charts.IChart;

                // Add a fade effect to the chart with a defined trigger
                slide.Timeline.MainSequence.AddEffect(
                    chart,
                    EffectType.Fade,
                    EffectSubtype.None,
                    EffectTriggerType.AfterPrevious);

                // Cast the main sequence to Sequence to add series animations
                Aspose.Slides.Animation.Sequence seq = (Aspose.Slides.Animation.Sequence)slide.Timeline.MainSequence;

                // Add appear effects for each series with defined triggers
                seq.AddEffect(chart,
                    EffectChartMajorGroupingType.BySeries,
                    0,
                    EffectType.Appear,
                    EffectSubtype.None,
                    EffectTriggerType.AfterPrevious);
                seq.AddEffect(chart,
                    EffectChartMajorGroupingType.BySeries,
                    1,
                    EffectType.Appear,
                    EffectSubtype.None,
                    EffectTriggerType.AfterPrevious);
                seq.AddEffect(chart,
                    EffectChartMajorGroupingType.BySeries,
                    2,
                    EffectType.Appear,
                    EffectSubtype.None,
                    EffectTriggerType.AfterPrevious);
                seq.AddEffect(chart,
                    EffectChartMajorGroupingType.BySeries,
                    3,
                    EffectType.Appear,
                    EffectSubtype.None,
                    EffectTriggerType.AfterPrevious);
                seq.AddEffect(chart,
                    EffectChartMajorGroupingType.BySeries,
                    4,
                    EffectType.Appear,
                    EffectSubtype.None,
                    EffectTriggerType.AfterPrevious);

                // Validate that animations have defined triggers (at least one effect present)
                if (slide.Timeline.MainSequence.Count == 0)
                {
                    Console.WriteLine("No animation triggers defined for the chart.");
                }

                // Save the presentation
                pres.Save("AnimatedChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file I/O, external resources)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}