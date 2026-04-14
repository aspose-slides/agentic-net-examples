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