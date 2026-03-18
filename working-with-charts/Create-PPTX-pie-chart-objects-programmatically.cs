using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace PieChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a pie chart without sample data
                IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 50, 50, 500, 400, false);

                // Set chart title
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("Sales Distribution");
                chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
                chart.ChartTitle.Height = 20;

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Get reference to the chart data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                int defaultWorksheetIndex = 0;

                // Add a single series
                IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), Aspose.Slides.Charts.ChartType.Pie);

                // Enable varied colors for the series
                series.ParentSeriesGroup.IsColorVaried = true;

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Product A"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Product B"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Product C"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 4, 0, "Product D"));

                // Add data points for the pie series
                series.DataPoints.AddDataPointForPieSeries(30); // Product A
                series.DataPoints.AddDataPointForPieSeries(20); // Product B
                series.DataPoints.AddDataPointForPieSeries(25); // Product C
                series.DataPoints.AddDataPointForPieSeries(25); // Product D

                // Save the presentation
                pres.Save("PieChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}