// -----------------------------------------------------------------------------
// Example: Add slide transition after chart animation using C#
//
// Description:
// Demonstrates how to add a slide transition that occurs after a chart animation
// using C# and Aspose.Slides for .NET. The example creates a presentation, adds a
// clustered column chart, applies a fade effect and a series-by-series appear
// animation to the chart, and then configures a slide transition that triggers
// immediately after the chart animation completes. This pattern can be used to
// automate PowerPoint workflows that require coordinated animations and transitions.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Slide, Transition, After, 
// Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding slide transitions that follow chart animations.
// - Build C# tools for advanced PowerPoint presentation sequencing.
// - Generate or transform PPTX files with coordinated animation and transition logic.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;

namespace SlideTransitionAfterChartAnimation
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = "OutputPresentation.pptx";

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a clustered column chart to the slide
                IChart chart = (IChart)slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 400, 300);

                // Add a fade effect to the chart
                slide.Timeline.MainSequence.AddEffect(
                    chart,
                    EffectType.Fade,
                    EffectSubtype.None,
                    EffectTriggerType.AfterPrevious);

                // Animate the chart by series
                Sequence sequence = (Sequence)slide.Timeline.MainSequence;
                sequence.AddEffect(
                    chart,
                    EffectChartMajorGroupingType.BySeries,
                    0,
                    EffectType.Appear,
                    EffectSubtype.None,
                    EffectTriggerType.AfterPrevious);

                // Set a custom slide transition that will trigger after the animation finishes
                slide.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
                slide.SlideShowTransition.AdvanceAfter = true;
                slide.SlideShowTransition.AdvanceAfterTime = 0; // immediate transition after animation

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file I/O, external resources)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
