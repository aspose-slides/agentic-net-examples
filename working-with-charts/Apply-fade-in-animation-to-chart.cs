// -----------------------------------------------------------------------------
// Example: Apply fade-in animation to a chart using C#
//
// Description:
// Demonstrates how to create a PowerPoint presentation, add a clustered column
// chart, and apply a fade‑in animation effect to the chart using Aspose.Slides for
// .NET. The example shows the necessary steps to build a standalone console
// application that generates a PPTX file with animated chart content.
//
// Keywords:
// C#, Aspose.Slides for .NET, PowerPoint, PPTX, Chart, Fade‑In, Animation, 
// EffectChartMajorGroupingType, EffectType, EffectTriggerType, Presentation 
// Automation, Office Automation
//
// Use Cases:
// - Programmatically add charts with entrance animations to PowerPoint slides.
// - Create automated reporting tools that generate animated PPTX files.
// - Build C# utilities for presentation preparation and visual enhancement.
// - Validate animation settings in generated presentations before distribution.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using AspNet.Slides.Animation;
using Aspose.Slides.Export;

namespace ApplyFadeInAnimationToChart
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a clustered column chart to the slide
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 400f, 300f);

                // Apply a fade-in animation to the chart when the slide appears
                // The animation will start after the previous animation (or immediately if none)
                slide.Timeline.MainSequence.AddEffect(
                    chart,
                    EffectChartMajorGroupingType.BySeries,
                    0,
                    EffectType.Fade,
                    EffectSubtype.None,
                    EffectTriggerType.AfterPrevious);

                // Save the presentation
                try
                {
                    presentation.Save("ChartFadeIn.pptx", SaveFormat.Pptx);
                }
                catch (Exception ex)
                {
                    // Handle unsupported format exception
                    // Format not supported
                    Console.WriteLine("Error saving presentation: " + ex.Message);
                }
            }
        }
    }
}
