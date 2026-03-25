using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output_animated.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Get the first shape and cast it to a chart
            Aspose.Slides.IShape shape = slide.Shapes[0];
            Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;
            if (chart == null)
            {
                Console.WriteLine("No chart found on the first slide.");
                return;
            }

            // Add a fade effect to the whole chart
            slide.Timeline.MainSequence.AddEffect(
                chart,
                Aspose.Slides.Animation.EffectType.Fade,
                Aspose.Slides.Animation.EffectSubtype.None,
                Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

            // Animate each series and its data points
            int seriesCount = chart.ChartData.Series.Count;
            for (int s = 0; s < seriesCount; s++)
            {
                // Animate the series as a whole
                ((Aspose.Slides.Animation.Sequence)slide.Timeline.MainSequence).AddEffect(
                    chart,
                    Aspose.Slides.Animation.EffectChartMajorGroupingType.BySeries,
                    s,
                    Aspose.Slides.Animation.EffectType.Appear,
                    Aspose.Slides.Animation.EffectSubtype.None,
                    Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

                // Animate individual data points within the series
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