using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output paths
        string dataDir = "Data" + Path.DirectorySeparatorChar;
        string inputFile = Path.Combine(dataDir, "input.pptx");
        string outputFile = Path.Combine(dataDir, "output_animated.pptx");

        // Verify that the input file exists
        if (!File.Exists(inputFile))
        {
            Console.WriteLine("Input file not found: " + inputFile);
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputFile);

        // Access the first slide
        Aspose.Slides.Slide slide = (Aspose.Slides.Slide)presentation.Slides[0];

        // Get the shapes collection of the slide
        Aspose.Slides.ShapeCollection shapes = (Aspose.Slides.ShapeCollection)slide.Shapes;

        // Assume the first shape is a chart
        Aspose.Slides.Charts.IChart chart = (Aspose.Slides.Charts.IChart)shapes[0];

        // Add a fade effect to the whole chart
        slide.Timeline.MainSequence.AddEffect(
            chart,
            EffectType.Fade,
            EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

        // Get the main sequence as a Sequence object
        Aspose.Slides.Animation.Sequence seq = (Aspose.Slides.Animation.Sequence)slide.Timeline.MainSequence;

        // Determine the number of categories and series
        int categoryCount = chart.ChartData.Categories.Count;
        int seriesCount = chart.ChartData.Series.Count;

        // Animate each data point by category
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