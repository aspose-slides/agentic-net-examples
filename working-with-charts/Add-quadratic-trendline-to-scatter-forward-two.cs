using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a scatter chart with smooth lines
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ScatterWithSmoothLines,
            0, 0, 400, 400);

        // Get the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Clear any default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Add a series to the chart
        chart.ChartData.Series.Add(workbook.GetCell(0, 1, 1, "Series 1"), chart.Type);
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

        // Populate the series with scatter data points (X, Y)
        series.DataPoints.AddDataPointForScatterSeries(
            workbook.GetCell(0, 2, 1, 1), workbook.GetCell(0, 2, 2, 2));
        series.DataPoints.AddDataPointForScatterSeries(
            workbook.GetCell(0, 3, 1, 2), workbook.GetCell(0, 3, 2, 4));
        series.DataPoints.AddDataPointForScatterSeries(
            workbook.GetCell(0, 4, 1, 3), workbook.GetCell(0, 4, 2, 6));

        // Add a quadratic (polynomial) trend line to the series
        Aspose.Slides.Charts.ITrendline trendline = series.TrendLines.Add(
            Aspose.Slides.Charts.TrendlineType.Polynomial);
        trendline.Order = 2;      // Quadratic
        trendline.Forward = 2;    // Extend forward by two category units

        // Save the presentation
        presentation.Save("ScatterChartWithQuadraticTrendline.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}