// -----------------------------------------------------------------------------
// Example: Remove animations from chart before adding new using C#
//
// Description:
// Demonstrates how to remove existing animations from a chart and then add a new
// animation effect using Aspose.Slides for .NET. The example loads a PPTX file,
// clears any chart animations on the first slide, applies a fade effect, and
// saves the result. This pattern helps automate PowerPoint presentation processing
// tasks such as animation management.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Remove, Animations, Chart,
// Before, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate removal of chart animations before applying new ones.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files with controlled animations in .NET applications.
// - Validate and adjust presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

namespace RemoveChartAnimations
{
    class Program
    {
        static void Main(string[] args)
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
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Assume the first slide contains a chart as the first shape
                    IChart chart = pres.Slides[0].Shapes[0] as IChart;
                    if (chart != null)
                    {
                        // Remove all existing animations for the chart
                        ISequence mainSequence = pres.Slides[0].Timeline.MainSequence;
                        mainSequence.RemoveByShape(chart);

                        // Add a new animation effect to the chart
                        mainSequence.AddEffect(
                            chart,
                            EffectChartMajorGroupingType.BySeries,
                            0,
                            EffectType.Fade,
                            EffectSubtype.None,
                            EffectTriggerType.OnClick);
                    }

                    // Save the modified presentation
                    try
                    {
                        pres.Save(outputPath, SaveFormat.Pptx);
                    }
                    catch (NotSupportedException)
                    {
                        // Format not supported
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
