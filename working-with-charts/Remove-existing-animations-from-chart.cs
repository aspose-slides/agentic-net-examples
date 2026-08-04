// -----------------------------------------------------------------------------
// Example: Remove existing animations from chart using C#
//
// Description:
// Demonstrates how to remove existing animations from chart using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Remove, Existing, Animations, 
// Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate remove existing animations from chart.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
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

                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
