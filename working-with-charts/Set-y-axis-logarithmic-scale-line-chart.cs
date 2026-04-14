using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a line chart with sample data
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Line, 50f, 50f, 500f, 400f);

        // Get the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Clear default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Add categories (X axis values)
        chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "1"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "2"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "3"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 4, 0, "4"));

        // Add a series
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
            workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

        // Populate series with exponential data (y = 2^x)
        series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 1, 2.0));
        series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 1, 4.0));
        series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 1, 8.0));
        series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 1, 16.0));

        // Apply logarithmic scale to the Y axis
        chart.Axes.VerticalAxis.IsLogarithmic = true;
        chart.Axes.VerticalAxis.LogBase = 10.0; // Optional: set log base

        // Save the presentation
        presentation.Save("LogarithmicLineChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation
        presentation.Dispose();
    }
}