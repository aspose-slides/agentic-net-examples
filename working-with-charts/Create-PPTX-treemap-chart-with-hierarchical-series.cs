using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace TreemapChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation pres = new Presentation())
                {
                    // Access the first slide
                    ISlide slide = pres.Slides[0];

                    // Add an empty Treemap chart (no sample data)
                    IChart chart = slide.Shapes.AddChart(
                        ChartType.Treemap,
                        0f, 0f, 500f, 400f,
                        false);

                    // Clear any default series and categories
                    chart.ChartData.Series.Clear();
                    chart.ChartData.Categories.Clear();

                    // Get the chart data workbook
                    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                    // Add a series
                    IChartSeries series = chart.ChartData.Series.Add(
                        workbook.GetCell(0, 0, 1, "Sales"),
                        ChartType.Treemap);

                    // Add hierarchical categories (Level 1, Level 2, Level 3)
                    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "North America"));
                    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "USA"));
                    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "New York"));

                    // Populate data points for the series
                    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 120));
                    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 80));
                    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 45));

                    // Enable varied colors for each data point
                    series.ParentSeriesGroup.IsColorVaried = true;

                    // Set chart title
                    chart.HasTitle = true;
                    chart.ChartTitle.AddTextFrameForOverriding("Regional Sales Treemap");
                    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
                    chart.ChartTitle.Height = 20;

                    // Save the presentation
                    pres.Save("TreemapChart.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}