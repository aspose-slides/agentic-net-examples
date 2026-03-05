using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace BubbleChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a bubble chart to the first slide
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Bubble,
                50f, 50f, 500f, 400f);

            // Set bubble size representation to Width (using the provided rule)
            chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = Aspose.Slides.Charts.BubbleSizeRepresentationType.Width;

            // Set bubble size scale (using the provided rule)
            chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150; // 150% of default size

            // Access the chart's data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add categories (required for bubble chart)
            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

            // Add a series
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
                workbook.GetCell(0, 0, 1, "Series 1"),
                chart.Type);

            // Add bubble data points (X, Y, BubbleSize)
            series.DataPoints.AddDataPointForBubbleSeries(10.0, 20.0, 30.0);
            series.DataPoints.AddDataPointForBubbleSeries(15.0, 25.0, 35.0);
            series.DataPoints.AddDataPointForBubbleSeries(20.0, 30.0, 40.0);

            // Save the presentation
            presentation.Save("BubbleChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}