using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AnimatedChartSvgExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";
            string svgPath = "slide.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load presentation and apply animations
            try
            {
                Presentation presentation = new Presentation(inputPath);

                // Get first slide
                ISlide slide = presentation.Slides[0];

                // Get first shape (assumed to be a chart)
                IShape shape = slide.Shapes[0];
                IChart chart = shape as IChart;
                if (chart == null)
                {
                    Console.WriteLine("The first shape is not a chart.");
                    presentation.Dispose();
                    return;
                }

                // Add fade effect to the whole chart
                slide.Timeline.MainSequence.AddEffect(
                    chart,
                    EffectType.Fade,
                    EffectSubtype.None,
                    EffectTriggerType.AfterPrevious);

                // Animate each series
                Int32 seriesCount = chart.ChartData.Series.Count;
                for (Int32 s = 0; s < seriesCount; s++)
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
                for (Int32 s = 0; s < seriesCount; s++)
                {
                    IChartSeries series = chart.ChartData.Series[s];
                    Int32 pointCount = series.DataPoints.Count;
                    for (Int32 p = 0; p < pointCount; p++)
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

                // Save the animated presentation
                presentation.Save(outputPath, SaveFormat.Pptx);

                // Export the first slide as SVG
                using (FileStream svgStream = File.Create(svgPath))
                {
                    slide.WriteAsSvg(svgStream);
                }

                // Dispose presentation
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., external URL issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}