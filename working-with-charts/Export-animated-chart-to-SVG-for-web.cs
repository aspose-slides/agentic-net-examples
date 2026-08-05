// -----------------------------------------------------------------------------
// Example: Export animated chart to SVG for web using C#
//
// Description:
// Demonstrates how to load a PowerPoint presentation, add fade and
// series/point animations to a chart, save the animated presentation, and
// export the first slide as an SVG file using Aspose.Slides for .NET. This
// console application shows the required steps for processing charts with
// animation and generating web‑friendly SVG output.
//
// Keywords:
// C#, Aspose.Slides for .NET, PowerPoint, PPTX, SVG, Export, Animated Chart,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding animations to charts in PowerPoint files.
// - Generate SVG representations of animated slides for web integration.
// - Build .NET tools for PowerPoint presentation manipulation and export.
// - Validate and preview animated chart workflows before publishing.
// -----------------------------------------------------------------------------
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
