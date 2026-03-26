using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string dataDir = "Data";
        string inputPath = Path.Combine(dataDir, "input.pptx");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        using (Presentation presentation = new Presentation(inputPath))
        {
            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Assume the first shape on the slide is a chart
            IChart chart = (IChart)slide.Shapes[0];

            // Add category-level animation for each category in the chart
            int categoriesCount = chart.ChartData.Categories.Count;
            for (int i = 0; i < categoriesCount; i++)
            {
                slide.Timeline.MainSequence.AddEffect(
                    chart,
                    EffectChartMajorGroupingType.ByCategory,
                    i,
                    EffectType.Fly,
                    EffectSubtype.Left,
                    EffectTriggerType.OnClick);
            }

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}