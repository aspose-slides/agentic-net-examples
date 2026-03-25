using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AddDataPointsToPieChart
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a pie chart (size 500x400 points)
                IChart chart = slide.Shapes.AddChart(ChartType.Pie, 0f, 0f, 500f, 400f);

                // Get the chart data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add a new series
                IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), ChartType.Pie);

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category A"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category B"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category C"));

                // Ensure the data points accept literal double values
                series.DataPoints.DataSourceTypeForValues = DataSourceType.DoubleLiterals;

                // Add data points to the series using literal double values
                series.DataPoints.AddDataPointForPieSeries(30.0);
                series.DataPoints.AddDataPointForPieSeries(45.0);
                series.DataPoints.AddDataPointForPieSeries(25.0);

                // Save the presentation
                string outputPath = "PieChartWithDataPoints.pptx";
                try
                {
                    pres.Save(outputPath, SaveFormat.Pptx);
                    Console.WriteLine("Presentation saved successfully to " + Path.GetFullPath(outputPath));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error saving presentation: " + ex.Message);
                }
            }
        }
    }
}