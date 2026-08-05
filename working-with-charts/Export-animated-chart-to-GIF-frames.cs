// -----------------------------------------------------------------------------
// Example: Export animated chart to GIF frames using C#
//
// Description:
// Demonstrates how to export an animated chart from a PowerPoint presentation
// to a GIF animation using C# and Aspose.Slides for .NET. The example loads a
// PPTX file, adds fade and appear effects to the chart series and data points,
// configures GIF export options, and saves the result as an animated GIF file.
// Developers can use this pattern to automate chart animation extraction,
// generate GIFs for web use, or integrate presentation processing into .NET
// applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, Animated, Chart,
// GIF, Frames, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate export of animated chart to GIF frames.
// - Build C# tools for PowerPoint chart animation extraction.
// - Generate GIF animations from PPTX charts for web or documentation.
// - Validate and preview chart animations in .NET applications.
// -----------------------------------------------------------------------------

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
        string outputPath = "animated_chart.gif";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                Aspose.Slides.ISlide slide = presentation.Slides[0];
                Aspose.Slides.IShape shape = slide.Shapes[0];
                Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;
                if (chart == null)
                {
                    Console.WriteLine("No chart found on the first slide.");
                    return;
                }

                slide.Timeline.MainSequence.AddEffect(
                    chart,
                    Aspose.Slides.Animation.EffectType.Fade,
                    Aspose.Slides.Animation.EffectSubtype.None,
                    Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

                int seriesCount = chart.ChartData.Series.Count;
                Aspose.Slides.Animation.Sequence sequence = (Aspose.Slides.Animation.Sequence)slide.Timeline.MainSequence;

                for (int s = 0; s < seriesCount; s++)
                {
                    sequence.AddEffect(
                        chart,
                        Aspose.Slides.Animation.EffectChartMajorGroupingType.BySeries,
                        s,
                        Aspose.Slides.Animation.EffectType.Appear,
                        Aspose.Slides.Animation.EffectSubtype.None,
                        Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

                    Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[s];
                    int pointCount = series.DataPoints.Count;
                    for (int p = 0; p < pointCount; p++)
                    {
                        sequence.AddEffect(
                            chart,
                            Aspose.Slides.Animation.EffectChartMinorGroupingType.ByElementInSeries,
                            s,
                            p,
                            Aspose.Slides.Animation.EffectType.Appear,
                            Aspose.Slides.Animation.EffectSubtype.None,
                            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);
                    }
                }

                Aspose.Slides.Export.GifOptions gifOptions = new Aspose.Slides.Export.GifOptions();
                gifOptions.FrameSize = new System.Drawing.Size(960, 720);
                gifOptions.DefaultDelay = 1000;
                gifOptions.TransitionFps = 30;

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Gif, gifOptions);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URLs)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
