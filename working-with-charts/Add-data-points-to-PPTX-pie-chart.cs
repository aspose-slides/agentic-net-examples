using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AddPieChartDataPoints
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a pie chart to the slide (float literals required)
            IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Pie,
                0f,
                0f,
                500f,
                500f);

            // Get the chart data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Remove the default generated series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add a new series
            IChartSeries series = chart.ChartData.Series.Add(
                workbook.GetCell(0, 0, 1, "Series 1"),
                Aspose.Slides.Charts.ChartType.Pie);

            // Add categories (optional for pie chart)
            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category A"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category B"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category C"));

            // Configure the data point collection to accept double literals
            series.DataPoints.DataSourceTypeForValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;

            // Add data points to the pie series
            series.DataPoints.AddDataPointForPieSeries(30.0);
            series.DataPoints.AddDataPointForPieSeries(45.0);
            series.DataPoints.AddDataPointForPieSeries(25.0);

            // Save the presentation
            pres.Save("PieChart.pptx", SaveFormat.Pptx);
        }
    }
}