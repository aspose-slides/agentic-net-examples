using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace DoughnutChartExample
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

                    // Add a doughnut chart
                    IChart chart = slide.Shapes.AddChart(ChartType.Doughnut, 50, 50, 500, 400);

                    // Set chart title
                    chart.HasTitle = true;
                    chart.ChartTitle.AddTextFrameForOverriding("Sample Doughnut Chart");

                    // Index of the default worksheet
                    int defaultWorksheetIndex = 0;

                    // Get the chart data workbook
                    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                    // Clear default series and categories
                    chart.ChartData.Series.Clear();
                    chart.ChartData.Categories.Clear();

                    // Add a new series
                    IChartSeries series = chart.ChartData.Series.Add(
                        workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"),
                        ChartType.Doughnut);

                    // Add categories
                    chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category A"));
                    chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category B"));
                    chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category C"));

                    // Populate series with data points
                    series.DataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 40));
                    series.DataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 30));
                    series.DataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));

                    // Set the doughnut hole size (10-90 percent)
                    series.ParentSeriesGroup.DoughnutHoleSize = 50;

                    // Show values on data labels
                    series.Labels.DefaultDataLabelFormat.ShowValue = true;

                    // Save the presentation
                    pres.Save("DoughnutChart.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}