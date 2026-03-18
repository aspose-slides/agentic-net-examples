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
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a clustered column chart to the slide
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 400);

                // Get the chart data workbook to manipulate cells
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Remove default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

                // Add series
                IChartSeries series1 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);
                IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);

                // Populate series data points
                series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 20));
                series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 50));
                series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 30));

                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 30));
                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 10));
                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 2, 60));

                // Save the updated presentation
                pres.Save("UpdatedChart.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}