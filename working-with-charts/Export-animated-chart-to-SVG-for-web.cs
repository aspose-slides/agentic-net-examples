using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

        // Add a fade effect to the chart
        slide.Timeline.MainSequence.AddEffect(
            chart,
            Aspose.Slides.Animation.EffectType.Fade,
            Aspose.Slides.Animation.EffectSubtype.None,
            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

        // Get the main sequence as a Sequence object
        Aspose.Slides.Animation.Sequence seq = (Aspose.Slides.Animation.Sequence)slide.Timeline.MainSequence;

        // Determine the number of categories and series
        int categoryCount = chart.ChartData.Categories.Count;
        int seriesCount = chart.ChartData.Series.Count;

        // Add appear effects for each element in each category
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
        string outputPptx = "AnimatedChart.pptx";
        presentation.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx);

        // Export the first slide as SVG
        string outputSvg = "AnimatedChart.svg";
        using (FileStream svgStream = File.Create(outputSvg))
        {
            slide.WriteAsSvg(svgStream);
        }

        // Clean up
        presentation.Dispose();
    }
}