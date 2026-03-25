using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

namespace ApplyCategoryAnimations
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect two arguments: input PPTX path and output PPTX path
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: ApplyCategoryAnimations <input.pptx> <output.pptx>");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file not found - " + inputPath);
                return;
            }

            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Access the first slide
                Slide slide = (Slide)presentation.Slides[0];

                // Access the shape collection of the slide
                ShapeCollection shapes = (ShapeCollection)slide.Shapes;

                // Assume the first shape is a chart
                IChart chart = (IChart)shapes[0];

                // Add a fade effect to the whole chart
                slide.Timeline.MainSequence.AddEffect(
                    chart,
                    EffectType.Fade,
                    EffectSubtype.None,
                    EffectTriggerType.AfterPrevious);

                // Get the main sequence as a concrete Sequence object
                Sequence seq = (Sequence)slide.Timeline.MainSequence;

                // Retrieve counts of categories and series
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
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
    }
}