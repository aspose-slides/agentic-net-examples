using System;
using System.IO;
using Aspose.Slides.Export;

namespace ChartAnimationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define the directory for output files
            string dataDir = "Data";
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 600f, 400f);

            // Apply a fade effect to the whole chart
            slide.Timeline.MainSequence.AddEffect(
                chart,
                Aspose.Slides.Animation.EffectType.Fade,
                Aspose.Slides.Animation.EffectSubtype.None,
                Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

            // Get the main sequence as a concrete Sequence object
            Aspose.Slides.Animation.Sequence seq = (Aspose.Slides.Animation.Sequence)slide.Timeline.MainSequence;

            // Determine the number of categories and series in the chart
            int categoryCount = chart.ChartData.Categories.Count;
            int seriesCount = chart.ChartData.Series.Count;

            // Animate each data point by category
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

            // Save the presentation
            string outputPath = Path.Combine(dataDir, "AnimatedChart.pptx");
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}