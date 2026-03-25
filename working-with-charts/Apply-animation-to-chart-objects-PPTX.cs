using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

namespace ApplyChartAnimation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Verify that an input file path is provided
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: ApplyChartAnimation <input-pptx-path>");
                return;
            }

            string inputPath = args[0];

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: File not found - " + inputPath);
                return;
            }

            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                {
                    ISlide slide = pres.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        IShape shape = slide.Shapes[shapeIndex];

                        // Determine if the shape is a chart
                        IChart chart = shape as IChart;
                        if (chart != null)
                        {
                            // Add an animation effect to the chart (animate by series, first series)
                            slide.Timeline.MainSequence.AddEffect(
                                chart,
                                EffectChartMajorGroupingType.BySeries,
                                0,
                                EffectType.Fly,
                                EffectSubtype.Left,
                                EffectTriggerType.OnClick);
                        }
                    }
                }

                // Define output path
                string outputPath = Path.Combine(
                    Path.GetDirectoryName(inputPath) ?? "",
                    Path.GetFileNameWithoutExtension(inputPath) + "_Animated.pptx");

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
        }
    }
}