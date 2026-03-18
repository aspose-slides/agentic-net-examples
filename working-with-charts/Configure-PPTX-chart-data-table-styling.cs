using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Presentation();
            var slide = presentation.Slides[0];
            var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 400);
            chart.HasTitle = true;
            chart.ChartTitle.AddTextFrameForOverriding("Custom Chart");
            chart.HasDataTable = true;

            var defaultWorksheetIndex = 0;
            var chartDataWorkbook = chart.ChartData.ChartDataWorkbook;
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add series with correct ChartType argument
            var series1 = chart.ChartData.Series.Add(chartDataWorkbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
            var series2 = chart.ChartData.Series.Add(chartDataWorkbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

            // Enable varied colors for each series
            series1.ParentSeriesGroup.IsColorVaried = true;
            series2.ParentSeriesGroup.IsColorVaried = true;

            // Add categories
            var cat1 = chart.ChartData.Categories.Add(chartDataWorkbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
            var cat2 = chart.ChartData.Categories.Add(chartDataWorkbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
            var cat3 = chart.ChartData.Categories.Add(chartDataWorkbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

            // Populate data points for series 1
            series1.DataPoints.AddDataPointForBarSeries(chartDataWorkbook.GetCell(defaultWorksheetIndex, 1, 1, 20));
            series1.DataPoints.AddDataPointForBarSeries(chartDataWorkbook.GetCell(defaultWorksheetIndex, 2, 1, 50));
            series1.DataPoints.AddDataPointForBarSeries(chartDataWorkbook.GetCell(defaultWorksheetIndex, 3, 1, 30));

            // Populate data points for series 2
            series2.DataPoints.AddDataPointForBarSeries(chartDataWorkbook.GetCell(defaultWorksheetIndex, 1, 2, 30));
            series2.DataPoints.AddDataPointForBarSeries(chartDataWorkbook.GetCell(defaultWorksheetIndex, 2, 2, 10));
            series2.DataPoints.AddDataPointForBarSeries(chartDataWorkbook.GetCell(defaultWorksheetIndex, 3, 2, 60));

            // Save the presentation
            presentation.Save("CustomizedChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}