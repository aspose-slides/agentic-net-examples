using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace TreemapChartExample
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

                // Add a treemap chart
                IChart chart = slide.Shapes.AddChart(ChartType.Treemap, 50, 50, 600, 400);

                // Clear any default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Get the chart data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Add a series for the treemap
                IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 0, "Series 1"), ChartType.Treemap);

                // Add categories (hierarchical levels)
                IChartCategory cat1 = chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category A"));
                IChartCategory cat2 = chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category B"));
                IChartCategory cat3 = chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category C"));

                // Add data points with size values (using literal doubles)
                IChartDataPoint dp1 = series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, 1, 1, 30.0));
                IChartDataPoint dp2 = series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, 2, 1, 60.0));
                IChartDataPoint dp3 = series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, 3, 1, 90.0));

                // Enable varied colors based on data magnitude (gradient-like effect)
                series.ParentSeriesGroup.IsColorVaried = true;

                // Optional: set the chart title
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("Treemap with Gradient Scale");
                chart.ChartTitle.TextFrameForOverriding.Text = "Treemap with Gradient Scale";

                // Save the presentation
                try
                {
                    pres.Save("TreemapGradient.pptx", SaveFormat.Pptx);
                }
                catch (ArgumentException ex)
                {
                    // Handle format not supported or other argument errors
                    Console.WriteLine("Error saving presentation: " + ex.Message);
                }
                catch (Exception ex)
                {
                    // General exception handling (e.g., external URL or web service errors)
                    Console.WriteLine("Unexpected error: " + ex.Message);
                }
            }
        }
    }
}