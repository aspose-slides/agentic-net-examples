using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        var dataDir = "Data" + Path.DirectorySeparatorChar;
        var inputPath = Path.Combine(dataDir, "input.pptx");
        var outputPath = Path.Combine(dataDir, "output_animated.pptx");

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        using (var presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Access the first slide
            var slide = (Aspose.Slides.Slide)presentation.Slides[0];

            // Get the shapes collection and assume the first shape is a chart
            var shapes = (Aspose.Slides.ShapeCollection)slide.Shapes;
            var chart = (Aspose.Slides.Charts.IChart)shapes[0];

            // Add an initial fade effect to the whole chart
            slide.Timeline.MainSequence.AddEffect(
                chart,
                Aspose.Slides.Animation.EffectType.Fade,
                Aspose.Slides.Animation.EffectSubtype.None,
                Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

            // Obtain the main sequence as a Sequence object
            var seq = (Aspose.Slides.Animation.Sequence)slide.Timeline.MainSequence;

            // Determine the number of categories and series in the chart
            var categoryCount = chart.ChartData.Categories.Count;
            var seriesCount = chart.ChartData.Series.Count;

            // Apply category‑level animations (by element in category) for each series and category
            for (int cat = 0; cat < categoryCount; cat++)
            {
                for (int ser = 0; ser < seriesCount; ser++)
                {
                    seq.AddEffect(
                        chart,
                        Aspose.Slides.Animation.EffectChartMinorGroupingType.ByElementInCategory,
                        ser,
                        cat,
                        Aspose.Slides.Animation.EffectType.Appear,
                        Aspose.Slides.Animation.EffectSubtype.None,
                        Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}