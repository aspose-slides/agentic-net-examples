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

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 500f, 400f);

        // Get the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Clear any default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Add categories
        chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));

        // Add a series
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
            workbook.GetCell(0, "B0", "Series 1"),
            chart.Type);

        // Add data points to the series
        series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, "B1", 10));
        series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, "B2", 20));

        // Modify the first data point: remove it and add a new one with a different value
        series.DataPoints[0].Remove();
        series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, "B1", 15));

        // Save the presentation
        presentation.Save("ModifiedSeriesData.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}