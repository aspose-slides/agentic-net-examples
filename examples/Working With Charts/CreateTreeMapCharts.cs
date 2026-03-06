using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Add a TreeMap chart
        IChart chart = slide.Shapes.AddChart(ChartType.Treemap, 0, 0, 500, 400);

        // Clear default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Get the chart data workbook
        IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Add a series
        IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

        // Add categories
        chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category A"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category B"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category C"));

        // Add data points with size values
        series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, 1, 1, 30));
        series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, 2, 1, 50));
        series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, 3, 1, 20));

        // Save the presentation
        presentation.Save("TreeMapChart_out.pptx", SaveFormat.Pptx);
    }
}