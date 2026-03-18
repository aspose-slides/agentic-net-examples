using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a doughnut chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.Doughnut, 50, 50, 500, 400);

            // Get the chart data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Remove default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add a series for the doughnut chart
            IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), ChartType.Doughnut);

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));

            // Add data points to the series
            series.DataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(0, 1, 1, 30));
            series.DataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(0, 2, 1, 70));

            // Set the inner radius (doughnut hole size) to 50%
            series.ParentSeriesGroup.DoughnutHoleSize = 50;

            // Save the presentation
            pres.Save("DoughnutHoleSize.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}