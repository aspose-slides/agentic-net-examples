// -----------------------------------------------------------------------------
// Example: Validate chart animation triggers before save using C#
//
// Description:
// Demonstrates how to validate chart animation triggers before save using C# 
// and Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Validate, Chart, Animation, 
// Triggers, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate validate chart animation triggers before save.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
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
