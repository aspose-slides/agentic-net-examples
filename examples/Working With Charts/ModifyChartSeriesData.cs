using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a clustered column chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 600f, 400f);

        // Remove any default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Get the workbook to create cells for categories and series data
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
        workbook.Clear(0);

        // Add categories (X‑axis labels)
        chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));

        // Add first series and its initial data points
        Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series.Add(
            workbook.GetCell(0, "B0", "Series 1"), chart.Type);
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, "B1", 10));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, "B2", 20));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, "B3", 30));

        // Add second series and its initial data points
        Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series.Add(
            workbook.GetCell(0, "C0", "Series 2"), chart.Type);
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, "C1", 15));
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, "C2", 25));
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, "C3", 35));

        // ---- Modify series data ----
        // Clear existing data points of the first series and add new values
        series1.DataPoints.Clear();
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, "B1", 12));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, "B2", 22));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, "B3", 32));

        // Clear existing data points of the second series and add new values
        series2.DataPoints.Clear();
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, "C1", 18));
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, "C2", 28));
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, "C3", 38));

        // Save the modified presentation
        presentation.Save("ModifiedChartSeries.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}