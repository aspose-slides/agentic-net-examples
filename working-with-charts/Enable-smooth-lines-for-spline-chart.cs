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

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a scatter chart with smooth lines (spline)
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

        // Get the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Clear default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Add series names
        int defaultWorksheetIndex = 0;
        chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
        chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

        // Add categories (X values)
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

        // Populate first series data points
        Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series[0];
        series1.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 1), workbook.GetCell(defaultWorksheetIndex, 1, 2, 2));
        series1.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 2), workbook.GetCell(defaultWorksheetIndex, 2, 2, 3));
        series1.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 3), workbook.GetCell(defaultWorksheetIndex, 3, 2, 4));

        // Enable smooth lines for the series
        series1.Smooth = true;

        // Adjust tension (not directly exposed; placeholder comment)
        // Note: Aspose.Slides does not provide a direct tension property; smoothness is controlled by the Smooth flag.

        // Populate second series data points
        Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series[1];
        series2.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 1), workbook.GetCell(defaultWorksheetIndex, 1, 2, 1));
        series2.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 2), workbook.GetCell(defaultWorksheetIndex, 2, 2, 2));
        series2.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 3), workbook.GetCell(defaultWorksheetIndex, 3, 2, 3));

        // Enable smooth lines for the second series as well
        series2.Smooth = true;

        // Save the presentation
        try
        {
            presentation.Save("SmoothSplineChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }

        // Dispose presentation
        presentation.Dispose();
    }
}