using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace FunnelChartDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a funnel chart to the first slide
            IChart chart = presentation.Slides[0].Shapes.AddChart(
                ChartType.Funnel, 50f, 50f, 500f, 400f);

            // Clear default categories and series
            chart.ChartData.Categories.Clear();
            chart.ChartData.Series.Clear();

            // Get the chart data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            workbook.Clear(0);

            // Add categories
            workbook.GetCell(0, 0, 0, "Stage 1");
            chart.ChartData.Categories.Add(workbook.GetCell(0, 0, 0, "Stage 1"));
            workbook.GetCell(0, 1, 0, "Stage 2");
            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Stage 2"));
            workbook.GetCell(0, 2, 0, "Stage 3");
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Stage 3"));
            workbook.GetCell(0, 3, 0, "Stage 4");
            chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Stage 4"));
            workbook.GetCell(0, 4, 0, "Stage 5");
            chart.ChartData.Categories.Add(workbook.GetCell(0, 4, 0, "Stage 5"));
            workbook.GetCell(0, 5, 0, "Stage 6");
            chart.ChartData.Categories.Add(workbook.GetCell(0, 5, 0, "Stage 6"));

            // Add a series for the funnel chart
            IChartSeries series = chart.ChartData.Series.Add(ChartType.Funnel);

            // Add data points for the series
            series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, 0, 1, 100));
            series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, 1, 1, 80));
            series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, 2, 1, 60));
            series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, 3, 1, 40));
            series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, 4, 1, 20));
            series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, 5, 1, 10));

            // Save the presentation
            string outputPath = "FunnelChartDemo.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}