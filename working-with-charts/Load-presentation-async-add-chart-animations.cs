using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartAnimationAsync
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output_animated.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Load the presentation asynchronously
            Presentation presentation = null;
            try
            {
                presentation = await Task.Run(() => new Presentation(inputPath));
            }
            catch (Exception ex)
            {
                // Handle unsupported format exception
                // Format not supported
                Console.WriteLine($"Failed to load presentation: {ex.Message}");
                return;
            }

            // Access the first slide and the first shape (assumed to be a chart)
            ISlide slide = presentation.Slides[0];
            IShape shape = slide.Shapes[0];
            IChart chart = shape as IChart;
            if (chart == null)
            {
                Console.WriteLine("The first shape is not a chart.");
                presentation.Dispose();
                return;
            }

            // Add a fade effect to the whole chart
            slide.Timeline.MainSequence.AddEffect(
                chart,
                EffectType.Fade,
                EffectSubtype.None,
                EffectTriggerType.AfterPrevious);

            // Animate each series
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
            presentation.Dispose();
        }
    }
}