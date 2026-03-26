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
            using (Presentation presentation = new Presentation())
            {
                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Add a pie chart to the slide
                IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);

                // Get the chart data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Remove default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add a new series (name stored in cell A1)
                IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 0, "Series 1"), ChartType.Pie);

                // Add categories (labels) for the pie slices
                chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category A"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category B"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category C"));

                // Ensure the data points accept literal double values
                series.DataPoints.DataSourceTypeForValues = DataSourceType.DoubleLiterals;

                // Add data points for each category
                series.DataPoints.AddDataPointForPieSeries(30); // Category A value
                series.DataPoints.AddDataPointForPieSeries(45); // Category B value
                series.DataPoints.AddDataPointForPieSeries(25); // Category C value

                // Save the presentation
                presentation.Save("AddPieChartDataPoints_out.pptx", SaveFormat.Pptx);
            }
        }
    }
}