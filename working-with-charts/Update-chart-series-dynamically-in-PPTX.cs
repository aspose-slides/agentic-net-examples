using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string dataDir = "Data/";
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

        // Get the collection of shapes on the slide
        Aspose.Slides.ShapeCollection shapes = (Aspose.Slides.ShapeCollection)slide.Shapes;

        // Assume the first shape is a chart
        Aspose.Slides.Charts.IChart chart = (Aspose.Slides.Charts.IChart)shapes[0];

        // Add a fade effect to the whole chart
        slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);

        // Get the main sequence as a Sequence object
        Aspose.Slides.Animation.Sequence seq = (Aspose.Slides.Animation.Sequence)slide.Timeline.MainSequence;

        // Determine the number of categories and series in the chart
        int categoryCount = chart.ChartData.Categories.Count;
        int seriesCount = chart.ChartData.Series.Count;

        // Add appear effects for each element in each category
        for (int cat = 0; cat < categoryCount; cat++)
        {
            for (int ser = 0; ser < seriesCount; ser++)
            {
                seq.AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, ser, cat, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
            }
        }

        // Save the modified presentation
        presentation.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}