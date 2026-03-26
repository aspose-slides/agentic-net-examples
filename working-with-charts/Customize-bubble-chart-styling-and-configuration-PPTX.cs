using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var pres = new Aspose.Slides.Presentation();

        // Add a bubble chart to the first slide
        var chart = pres.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.Bubble, 50f, 50f, 500f, 400f);

        // Set bubble size representation to Width
        chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = Aspose.Slides.Charts.BubbleSizeRepresentationType.Width;

        // Set bubble size scale (e.g., 150%)
        chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;

        // Access the chart data workbook
        var defaultWorksheetIndex = 0;
        var fact = chart.ChartData.ChartDataWorkbook;

        // Remove default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Add a new series
        var series = chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);

        // Add categories
        chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
        chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
        chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

        // Add data points (X, Y, BubbleSize) for the bubble series
        series.DataPoints.AddDataPointForBubbleSeries(
            fact.GetCell(defaultWorksheetIndex, 1, 1, 1.0),
            fact.GetCell(defaultWorksheetIndex, 1, 2, 4.0),
            fact.GetCell(defaultWorksheetIndex, 1, 3, 10.0));

        series.DataPoints.AddDataPointForBubbleSeries(
            fact.GetCell(defaultWorksheetIndex, 2, 1, 2.0),
            fact.GetCell(defaultWorksheetIndex, 2, 2, 5.0),
            fact.GetCell(defaultWorksheetIndex, 2, 3, 20.0));

        series.DataPoints.AddDataPointForBubbleSeries(
            fact.GetCell(defaultWorksheetIndex, 3, 1, 3.0),
            fact.GetCell(defaultWorksheetIndex, 3, 2, 6.0),
            fact.GetCell(defaultWorksheetIndex, 3, 3, 30.0));

        // Show bubble size values in data labels
        series.Labels.DefaultDataLabelFormat.ShowBubbleSize = true;

        // Save the presentation
        pres.Save("BubbleChartPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}