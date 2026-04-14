using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file path
        string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "TrendLineExample.pptx");

        // Create a new presentation
        Presentation presentation = new Presentation();

        // Add a line chart to the first slide
        IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 50f, 50f, 600f, 400f);

        // Access the chart's workbook
        IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Clear any default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Add categories (e.g., months)
        chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Jan"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Feb"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Mar"));

        // Add a series
        IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, "B1", "Series 1"), chart.Type);

        // Add data points to the series
        series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, "B2", 10));
        series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, "B3", 20));
        series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, "B4", 30));

        // Add an exponential trend line to the series for forecasting
        ITrendline trendline = series.TrendLines.Add(TrendlineType.Exponential);
        trendline.DisplayEquation = false;
        trendline.DisplayRSquaredValue = false;

        // Save the presentation
        try
        {
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
    }
}