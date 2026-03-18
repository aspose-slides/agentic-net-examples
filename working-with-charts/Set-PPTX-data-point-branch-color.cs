using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartDataPointColorExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                var presentation = new Presentation();

                // Access the first slide
                var slide = presentation.Slides[0];

                // Add a clustered column chart
                var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

                // Get the chart data workbook
                var workbook = chart.ChartData.ChartDataWorkbook;

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add a new series
                var series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

                // Add data points to the series
                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 20));
                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 50));
                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 30));

                // Assign a specific color to the second data point (index 1)
                var targetDataPoint = series.DataPoints[1];
                targetDataPoint.Format.Fill.SolidFillColor.Color = Color.Orange;

                // Save the presentation
                presentation.Save("ChartDataPointColor.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}