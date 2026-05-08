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