using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string dataDir = "Data" + Path.DirectorySeparatorChar;
        string inputPath = Path.Combine(dataDir, "input.pptx");
        string outputPath = Path.Combine(dataDir, "output.pptx");

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
                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Get the first shape and cast it to a chart
                IShapeCollection shapes = slide.Shapes;
                IChart chart = shapes[0] as IChart;
                if (chart == null)
                {
                    Console.WriteLine("No chart found on the first slide.");
                    return;
                }

                // Add an initial fade effect for the chart
                slide.Timeline.MainSequence.AddEffect(
                    chart,
                    EffectType.Fade,
                    EffectSubtype.None,
                    EffectTriggerType.AfterPrevious);

                // Get the main sequence as a concrete Sequence object
                Sequence seq = (Sequence)slide.Timeline.MainSequence;

                // Determine the number of categories and series
                int categoryCount = chart.ChartData.Categories.Count;
                int seriesCount = chart.ChartData.Series.Count;

                // Animate each element in each category with a 2‑second pause between them
                for (int cat = 0; cat < categoryCount; cat++)
                {
                    for (int ser = 0; ser < seriesCount; ser++)
                    {
                        IEffect effect = seq.AddEffect(
                            chart,
                            EffectChartMinorGroupingType.ByElementInCategory,
                            ser,
                            cat,
                            EffectType.Appear,
                            EffectSubtype.None,
                            EffectTriggerType.AfterPrevious);

                        // Set a 2‑second delay after each effect
                        effect.Timing.TriggerDelayTime = 2.0f;
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle any errors (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}