using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a bubble chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Bubble, 50f, 50f, 600f, 400f);

        // Set bubble size scale (e.g., 150% of default)
        chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;

        // Set bubble size representation to Width
        chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = Aspose.Slides.Charts.BubbleSizeRepresentationType.Width;

        // Get the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Clear default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Add categories
        chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

        // Add a series
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
            workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

        // Add data points (X, Y, BubbleSize)
        series.DataPoints.AddDataPointForBubbleSeries(
            workbook.GetCell(0, 1, 1, 1.0), // X value
            workbook.GetCell(0, 1, 2, 4.0), // Y value
            workbook.GetCell(0, 1, 3, 30.0) // Bubble size
        );

        series.DataPoints.AddDataPointForBubbleSeries(
            workbook.GetCell(0, 2, 1, 2.0),
            workbook.GetCell(0, 2, 2, 5.0),
            workbook.GetCell(0, 2, 3, 50.0)
        );

        series.DataPoints.AddDataPointForBubbleSeries(
            workbook.GetCell(0, 3, 1, 3.0),
            workbook.GetCell(0, 3, 2, 6.0),
            workbook.GetCell(0, 3, 3, 70.0)
        );

        // Show bubble size values in data labels
        series.Labels.DefaultDataLabelFormat.ShowBubbleSize = true;

        // Save the presentation
        string outputPath = "BubbleChart.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}