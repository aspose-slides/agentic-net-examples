using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

        // Access chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Clear default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Add categories
        int defaultWorksheetIndex = 0;
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

        // Add series
        Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), Aspose.Slides.Charts.ChartType.ClusteredColumn);
        Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), Aspose.Slides.Charts.ChartType.ClusteredColumn);

        // Populate series data
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 20));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 50));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));

        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 30));
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 10));
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 60));

        // Add a linear trendline to the first series
        Aspose.Slides.Charts.ITrendline linearTrendline = series1.TrendLines.Add(Aspose.Slides.Charts.TrendlineType.Linear);
        linearTrendline.TrendlineType = Aspose.Slides.Charts.TrendlineType.Linear;
        linearTrendline.DisplayEquation = true;
        linearTrendline.DisplayRSquaredValue = true;

        // Add a polynomial trendline to the second series
        Aspose.Slides.Charts.ITrendline polyTrendline = series2.TrendLines.Add(Aspose.Slides.Charts.TrendlineType.Polynomial);
        polyTrendline.TrendlineType = Aspose.Slides.Charts.TrendlineType.Polynomial;
        polyTrendline.Order = 3; // cubic
        polyTrendline.DisplayEquation = true;

        // Save the presentation
        presentation.Save("TrendlinesExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}