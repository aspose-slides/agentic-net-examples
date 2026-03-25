using System;
using Aspose.Slides.Export;

namespace FunnelChartDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Add a funnel chart to the first slide
                Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.Funnel, 50, 50, 500, 400);

                // Clear default categories and series
                chart.ChartData.Categories.Clear();
                chart.ChartData.Series.Clear();

                // Get the chart data workbook
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Clear any existing data in the workbook (index 0)
                workbook.Clear(0);

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Stage 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Stage 2"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Stage 3"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Stage 4"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Stage 5"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Stage 6"));

                // Add a series for the funnel chart
                Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(Aspose.Slides.Charts.ChartType.Funnel);

                // Populate series data points
                series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B1", 100));
                series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B2", 80));
                series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B3", 60));
                series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B4", 40));
                series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B5", 20));
                series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B6", 10));

                // Save the presentation
                presentation.Save("FunnelChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}