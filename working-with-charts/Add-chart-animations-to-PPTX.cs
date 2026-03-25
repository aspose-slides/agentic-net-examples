using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartAnimationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output_animated.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file not found - " + inputPath);
                return;
            }

            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Get the first shape on the slide
            IShape shape = slide.Shapes[0];

            // Cast the shape to a chart
            IChart chart = shape as IChart;
            if (chart == null)
            {
                Console.WriteLine("The first shape is not a chart.");
                presentation.Save(outputPath, SaveFormat.Pptx);
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
        }
    }
}