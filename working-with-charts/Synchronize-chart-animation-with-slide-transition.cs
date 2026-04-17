using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.SlideShow;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Get the first slide
        ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 400, 300);

        // Prepare chart data
        IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        chart.ChartData.Series.Add(workbook.GetCell(0, 1, 0, "Series 1"), chart.Type);
        chart.ChartData.Series.Add(workbook.GetCell(0, 2, 0, "Series 2"), chart.Type);
        chart.ChartData.Categories.Add(workbook.GetCell(0, 0, 1, "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 0, 2, "Category 2"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 0, 3, "Category 3"));

        IChartSeries series0 = chart.ChartData.Series[0];
        series0.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 20));
        series0.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 50));
        series0.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 3, 30));

        IChartSeries series1 = chart.ChartData.Series[1];
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 30));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 10));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 3, 60));

        // Animate the chart by series
        Sequence sequence = (Sequence)slide.Timeline.MainSequence;
        sequence.AddEffect(chart, EffectChartMajorGroupingType.BySeries, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
        sequence.AddEffect(chart, EffectChartMajorGroupingType.BySeries, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

        // Apply a slide transition and synchronize its timing
        slide.SlideShowTransition.Type = TransitionType.Fade;
        slide.SlideShowTransition.AdvanceOnClick = true;
        slide.SlideShowTransition.AdvanceAfterTime = 5000; // 5 seconds

        // Save the presentation before exiting
        string outputPath = "ChartAnimationWithTransition.pptx";
        presentation.Save(outputPath, SaveFormat.Pptx);
    }
}