using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace FunnelChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a funnel chart to the first slide
            IChart chart = presentation.Slides[0].Shapes.AddChart(
                ChartType.Funnel, 0f, 0f, 500f, 400f);

            // Remove any default categories and series
            chart.ChartData.Categories.Clear();
            chart.ChartData.Series.Clear();

            // Get the chart data workbook and clear its contents
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            workbook.Clear(0);

            // Add categories (stages) to the chart
            chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Stage 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Stage 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Stage 3"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Stage 4"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Stage 5"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Stage 6"));

            // Add a series for the funnel chart
            IChartSeries series = chart.ChartData.Series.Add(ChartType.Funnel);

            // Add data points (values) to the series
            series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B1", 120.0));
            series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B2", 100.0));
            series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B3", 80.0));
            series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B4", 60.0));
            series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B5", 40.0));
            series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B6", 20.0));

            // Save the presentation
            presentation.Save("FunnelChart.pptx", SaveFormat.Pptx);
        }
    }
}