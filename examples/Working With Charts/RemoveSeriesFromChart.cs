using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a clustered column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 0f, 0f, 500f, 400f);

        // Clear default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Get the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;
        int defaultWorksheetIndex = 0;

        // Add two series
        Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series.Add(wb.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
        Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series.Add(wb.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

        // Add categories
        chart.ChartData.Categories.Add(wb.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
        chart.ChartData.Categories.Add(wb.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));

        // Populate data points for both series
        series1.DataPoints.AddDataPointForBarSeries(wb.GetCell(defaultWorksheetIndex, 1, 1, 10));
        series1.DataPoints.AddDataPointForBarSeries(wb.GetCell(defaultWorksheetIndex, 2, 1, 20));
        series2.DataPoints.AddDataPointForBarSeries(wb.GetCell(defaultWorksheetIndex, 1, 2, 30));
        series2.DataPoints.AddDataPointForBarSeries(wb.GetCell(defaultWorksheetIndex, 2, 2, 40));

        // Remove the second series from the chart
        chart.ChartData.Series.Remove(series2);

        // Save the presentation
        pres.Save("RemoveSeries_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}