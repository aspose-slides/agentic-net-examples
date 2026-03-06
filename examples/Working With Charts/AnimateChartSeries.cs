using Aspose.Slides;
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

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 500f, 400f);

        // Clear any default categories and series
        chart.ChartData.Categories.Clear();
        chart.ChartData.Series.Clear();

        // Get the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
        int defaultWorksheetIndex = 0;

        // Add categories
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

        // Add series
        chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
        chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

        // Populate data for Series 1
        Aspose.Slides.Charts.IChartSeries series0 = chart.ChartData.Series[0];
        series0.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 20));
        series0.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 50));
        series0.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));

        // Populate data for Series 2
        Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series[1];
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 30));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 10));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 60));

        // Add a fade effect to the whole chart
        slide.Timeline.MainSequence.AddEffect(
            chart,
            EffectType.Fade,
            EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

        // Cast the main sequence to a Sequence object for adding series effects
        Aspose.Slides.Animation.Sequence seq = (Aspose.Slides.Animation.Sequence)slide.Timeline.MainSequence;

        // Animate each series individually using the Appear effect
        int seriesCount = chart.ChartData.Series.Count;
        for (int s = 0; s < seriesCount; s++)
        {
            seq.AddEffect(
                chart,
                EffectChartMajorGroupingType.BySeries,
                s,
                EffectType.Appear,
                EffectSubtype.None,
                EffectTriggerType.AfterPrevious);
        }

        // Save the presentation
        presentation.Save("ChartSeriesAnimation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}