using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

namespace AsposeSlidesAnimationExample
{
    class Program
    {
        static void Main()
        {
            // Input and output file paths
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Get the first slide
                var slide = presentation.Slides[0];

                // Get the first shape on the slide (assumed to be a chart)
                var shape = slide.Shapes[0];

                // Cast the shape to a chart
                var chart = shape as Aspose.Slides.Charts.IChart;
                if (chart == null)
                {
                    Console.WriteLine("The first shape is not a chart.");
                    return;
                }

                // Add a fade effect to the whole chart
                slide.Timeline.MainSequence.AddEffect(
                    chart,
                    Aspose.Slides.Animation.EffectType.Fade,
                    Aspose.Slides.Animation.EffectSubtype.None,
                    Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

                // Add an appear effect for each series in the chart
                var seriesCount = chart.ChartData.Series.Count;
                for (int s = 0; s < seriesCount; s++)
                {
                    ((Aspose.Slides.Animation.Sequence)slide.Timeline.MainSequence).AddEffect(
                        chart,
                        Aspose.Slides.Animation.EffectChartMajorGroupingType.BySeries,
                        s,
                        Aspose.Slides.Animation.EffectType.Appear,
                        Aspose.Slides.Animation.EffectSubtype.None,
                        Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }

            Console.WriteLine("Presentation saved to: " + outputPath);
        }
    }
}