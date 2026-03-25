using System;
using System.IO;
using Aspose.Slides.Export;

namespace AnimatedChartDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "AnimatedChart_out.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file not found - " + inputPath);
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Get the first shape on the slide (assumed to be a chart)
            Aspose.Slides.IShape shape = slide.Shapes[0];
            Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;
            if (chart == null)
            {
                Console.WriteLine("The first shape is not a chart.");
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                return;
            }

            // Add a fade effect for the whole chart
            slide.Timeline.MainSequence.AddEffect(
                chart,
                Aspose.Slides.Animation.EffectType.Fade,
                Aspose.Slides.Animation.EffectSubtype.None,
                Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

            // Animate each series
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

            // Animate each data point within each series
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

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}