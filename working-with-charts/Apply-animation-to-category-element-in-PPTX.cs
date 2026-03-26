using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AnimationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string dataDir = @"C:\Data\";
            string inputFile = Path.Combine(dataDir, "input.pptx");
            string outputFile = Path.Combine(dataDir, "output.pptx");

            // Verify that the input file exists
            if (!File.Exists(inputFile))
            {
                Console.WriteLine("Input file does not exist: " + inputFile);
                return;
            }

            // Load the presentation
            Presentation presentation = new Presentation(inputFile);

            // Get the first slide
            Slide slide = (Slide)presentation.Slides[0];

            // Get the collection of shapes on the slide
            ShapeCollection shapes = (ShapeCollection)slide.Shapes;

            // Assume the first shape is a chart
            IChart chart = (IChart)shapes[0];

            // Add a fade effect to the whole chart
            slide.Timeline.MainSequence.AddEffect(
                chart,
                EffectType.Fade,
                EffectSubtype.None,
                EffectTriggerType.AfterPrevious);

            // Cast the main sequence to Sequence for adding category element effects
            Sequence seq = (Sequence)slide.Timeline.MainSequence;

            // Get counts of categories and series
            int categoryCount = chart.ChartData.Categories.Count;
            int seriesCount = chart.ChartData.Series.Count;

            // Animate each element in each category
            for (int cat = 0; cat < categoryCount; cat++)
            {
                for (int ser = 0; ser < seriesCount; ser++)
                {
                    seq.AddEffect(
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
            presentation.Save(outputFile, SaveFormat.Pptx);
        }
    }
}