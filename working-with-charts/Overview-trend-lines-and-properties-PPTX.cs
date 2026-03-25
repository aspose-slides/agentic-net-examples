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

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a line chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Line,
            50f, 50f, 500f, 400f);

        // Access the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Clear default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Add categories (e.g., months)
        int defaultWorksheetIndex = 0;
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Jan"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Feb"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Mar"));

        // Add a series (e.g., Sales)
        Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series.Add(
            workbook.GetCell(defaultWorksheetIndex, 0, 1, "Sales"),
            chart.Type);

        // Populate series data points
        series1.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 200));
        series1.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 250));
        series1.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 300));

        // Add a linear trendline to the series
        Aspose.Slides.Charts.ITrendline trendline = series1.TrendLines.Add(Aspose.Slides.Charts.TrendlineType.Linear);
        trendline.DisplayEquation = true;
        trendline.DisplayRSquaredValue = true;
        trendline.Backward = 1; // Extend one category backward
        trendline.Forward = 1;  // Extend one category forward

        // Save the presentation
        presentation.Save("TrendlinesOverview.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up
        presentation.Dispose();
    }
}