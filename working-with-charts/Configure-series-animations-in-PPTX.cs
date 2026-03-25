using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ConfigureSeriesAnimations
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the input presentation
            string inputPath = "input.pptx";
            // Path to the output presentation
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file not found - " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        ISlide slide = presentation.Slides[slideIndex];

                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];

                            // Process only chart shapes
                            if (shape is IChart chart)
                            {
                                // Get the number of series in the chart
                                int seriesCount = chart.ChartData.Series.Count;

                                // Add an animation effect for each series
                                for (int seriesIdx = 0; seriesIdx < seriesCount; seriesIdx++)
                                {
                                    // Add a Fly effect that animates the series on click
                                    slide.Timeline.MainSequence.AddEffect(
                                        chart,
                                        EffectChartMajorGroupingType.BySeries,
                                        seriesIdx,
                                        EffectType.Fly,
                                        EffectSubtype.Left,
                                        EffectTriggerType.OnClick);
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }

                Console.WriteLine("Presentation saved successfully to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}