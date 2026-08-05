// -----------------------------------------------------------------------------
// Example: Apply element animation to series point two second using C#
//
// Description:
// Demonstrates how to apply a two‑second element animation to a specific series
// point in a chart using Aspose.Slides for .NET. The example loads an existing
// presentation, adds a fade effect to the whole chart, then adds an appear
// animation to the second point of the first series with a custom duration of
// two seconds, and finally saves the modified presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Element, Animation,
// Series, Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate applying element animation to a specific chart series point.
// - Build C# tools for PowerPoint presentation processing with custom timings.
// - Generate or transform PPTX files with animated chart elements in .NET
//   applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

namespace ApplyElementAnimation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Get the first slide
                    ISlide slide = presentation.Slides[0];

                    // Assume the first shape is a chart; otherwise exit
                    IShape shape = slide.Shapes[0];
                    IChart chart = shape as IChart;
                    if (chart == null)
                    {
                        Console.WriteLine("No chart found on the first slide.");
                        return;
                    }

                    // Add a fade effect to the whole chart
                    slide.Timeline.MainSequence.AddEffect(
                        chart,
                        EffectType.Fade,
                        EffectSubtype.None,
                        EffectTriggerType.AfterPrevious);

                    // Index of the series and point to animate
                    int seriesIndex = 0;   // first series
                    int pointIndex = 1;    // second point in the series

                    // Add animation for the specific point
                    IEffect pointEffect = ((Sequence)slide.Timeline.MainSequence).AddEffect(
                        chart,
                        EffectChartMinorGroupingType.ByElementInSeries,
                        seriesIndex,
                        pointIndex,
                        EffectType.Appear,
                        EffectSubtype.None,
                        EffectTriggerType.AfterPrevious);

                    // Set custom duration of two seconds (2000 milliseconds)
                    // The Timing.Duration property expects a value in milliseconds
                    pointEffect.Timing.Duration = 2000;

                    // Save the presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                // Comment: format not supported or other error occurred
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
