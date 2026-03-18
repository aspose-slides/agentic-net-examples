using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var pres = new Aspose.Slides.Presentation();
            var slide = pres.Slides[0];

            // Add a clustered column chart
            var chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Access the chart data workbook
            var workbook = chart.ChartData.ChartDataWorkbook;

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Define worksheet index
            var defaultWorksheetIndex = 0;

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

            // Add series
            var series1 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
            var series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

            // Populate first series data points
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 20));
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 50));
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));

            // Populate second series data points
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 30));
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 10));
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 60));

            // Save the presentation
            pres.Save("UpdatedChart.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}