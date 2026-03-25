using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace CategoryChartAnimation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            var inputPath = "input.pptx";
            var outputPath = "output_animated.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Error: Input file '{inputPath}' not found.");
                return;
            }

            // Load the presentation
            using (var presentation = new Presentation(inputPath))
            {
                // Access the first slide
                var slide = (Slide)presentation.Slides[0];

                // Access the first shape on the slide and cast it to a chart
                var shapes = (ShapeCollection)slide.Shapes;
                var chart = (IChart)shapes[0];

                // Add an initial fade effect for the whole chart
                slide.Timeline.MainSequence.AddEffect(
                    chart,
                    EffectType.Fade,
                    EffectSubtype.None,
                    EffectTriggerType.AfterPrevious);

                // Get the main sequence to add category‑level effects
                var sequence = (Sequence)slide.Timeline.MainSequence;

                // Determine the number of categories and series in the chart
                var categoryCount = chart.ChartData.Categories.Count;
                var seriesCount = chart.ChartData.Series.Count;

                // Add appear effects for each element in every category
                for (var cat = 0; cat < categoryCount; cat++)
                {
                    for (var ser = 0; ser < seriesCount; ser++)
                    {
                        sequence.AddEffect(
                            chart,
                            EffectChartMinorGroupingType.ByElementInCategory,
                            ser,
                            cat,
                            EffectType.Appear,
                            EffectSubtype.None,
                            EffectTriggerType.AfterPrevious);
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }

            Console.WriteLine("Animation applied and presentation saved successfully.");
        }
    }
}