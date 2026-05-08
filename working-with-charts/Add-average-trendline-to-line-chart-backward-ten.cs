using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a line chart on the first slide
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.Line, 50, 50, 500, 400);

            // Get the chart data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Add a series
            chart.ChartData.Series.Add(workbook.GetCell(0, 1, 1, "Series 1"), chart.Type);

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(0, 0, 1, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 0, 2, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 0, 3, "Category 3"));

            // Add data points for the series
            chart.ChartData.Series[0].DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 1, 10));
            chart.ChartData.Series[0].DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 2, 20));
            chart.ChartData.Series[0].DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 3, 15));

            // Add an average (moving average) trend line to the series
            Aspose.Slides.Charts.ITrendline trendline = chart.ChartData.Series[0].TrendLines.Add(Aspose.Slides.Charts.TrendlineType.MovingAverage);
            // Configure backward length to cover ten points
            trendline.Backward = 10;

            // Save the presentation
            presentation.Save("AverageTrendLine.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}