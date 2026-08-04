// -----------------------------------------------------------------------------
// Example: Apply point animation to series point two second using C#
//
// Description:
// Demonstrates how to apply a two‑second point animation to a specific series
// point in a chart using C# and Aspose.Slides for .NET. The example loads an
// existing presentation, locates the first chart, adds a fade effect to the
// chart, then applies an appear animation to the second point of the first
// series with a custom duration of two seconds. The modified presentation is
// saved as a new PPTX file. This pattern can be used to automate PowerPoint
// animation workflows in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Point, Animation,
// Series, Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate applying point‑level animations to chart series in PowerPoint.
// - Build C# tools for detailed presentation animation control.
// - Generate or transform PPTX files with custom animation timings.
// - Validate and test presentation animation workflows before publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Get the first slide
                    ISlide slide = presentation.Slides[0];

                    // Assume the first shape on the slide is a chart
                    IShape shape = slide.Shapes[0];
                    IChart chart = shape as IChart;
                    if (chart == null)
                    {
                        Console.WriteLine("No chart found on the first slide.");
                        return;
                    }

                    // Add a fade effect to the whole chart (optional visual cue)
                    slide.Timeline.MainSequence.AddEffect(
                        chart,
                        EffectType.Fade,
                        EffectSubtype.None,
                        EffectTriggerType.AfterPrevious);

                    // Define the target series and point indices (zero‑based)
                    int targetSeriesIndex = 0; // first series
                    int targetPointIndex = 1;  // second point in the series

                    // Add an appearance effect for the specific point
                    Sequence sequence = (Sequence)slide.Timeline.MainSequence;
                    IEffect pointEffect = sequence.AddEffect(
                        chart,
                        EffectChartMinorGroupingType.ByElementInSeries,
                        targetSeriesIndex,
                        targetPointIndex,
                        EffectType.Appear,
                        EffectSubtype.None,
                        EffectTriggerType.AfterPrevious);

                    // Set a custom duration of two seconds for this effect
                    pointEffect.Timing.Duration = 2.0f;

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported – handle accordingly
                Console.WriteLine("The specified file format is not supported for saving.");
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
