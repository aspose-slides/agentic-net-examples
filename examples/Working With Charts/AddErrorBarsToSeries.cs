using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        var slide = presentation.Slides[0];

        // Add a clustered column chart
        var chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

        // Get the chart data workbook
        var defaultWorksheetIndex = 0;
        var chartDataWorkbook = chart.ChartData.ChartDataWorkbook;

        // Clear default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Add categories
        chart.ChartData.Categories.Add(chartDataWorkbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
        chart.ChartData.Categories.Add(chartDataWorkbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
        chart.ChartData.Categories.Add(chartDataWorkbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

        // Add a series
        var series = chart.ChartData.Series.Add(chartDataWorkbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);

        // Add data points
        series.DataPoints.AddDataPointForBarSeries(chartDataWorkbook.GetCell(defaultWorksheetIndex, 1, 1, 10));
        series.DataPoints.AddDataPointForBarSeries(chartDataWorkbook.GetCell(defaultWorksheetIndex, 2, 1, 20));
        series.DataPoints.AddDataPointForBarSeries(chartDataWorkbook.GetCell(defaultWorksheetIndex, 3, 1, 15));

        // Configure Y error bars if allowed
        if (Aspose.Slides.Charts.ChartTypeCharacterizer.IsErrorBarsYAllowed(chart.Type))
        {
            var errorBars = series.ErrorBarsYFormat;
            errorBars.IsVisible = true;
            errorBars.Type = Aspose.Slides.Charts.ErrorBarType.Both;
            errorBars.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Fixed;
            errorBars.Value = 5f; // Fixed error bar length
        }

        // Save the presentation
        presentation.Save("ErrorBarsChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}