using System;
using System.Drawing;
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

        // Add a clustered column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 400);

        // Access the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Clear default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Add two series
        Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);
        Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);

        // Add categories
        chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));

        // Populate data points for series 1
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 10));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 20));

        // Populate data points for series 2
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 30));
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 40));

        // Remove the second series (index 1)
        chart.ChartData.Series.RemoveAt(1);

        // Save the presentation
        presentation.Save("UpdateSeriesPresentation.pptx", SaveFormat.Pptx);
    }
}