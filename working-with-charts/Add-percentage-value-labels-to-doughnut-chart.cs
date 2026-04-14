using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        var slide = presentation.Slides[0];

        // Add a doughnut chart
        var chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Doughnut, 50, 50, 400, 400);

        // Set the doughnut hole size
        chart.ChartData.Series[0].ParentSeriesGroup.DoughnutHoleSize = 50;

        // Prepare chart data
        var workbook = chart.ChartData.ChartDataWorkbook;
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

        var series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);
        series.DataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(0, 1, 1, 30));
        series.DataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(0, 2, 1, 50));
        series.DataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(0, 3, 1, 20));

        // Show both value and percentage on each data label
        series.Labels.DefaultDataLabelFormat.ShowValue = true;
        series.Labels.DefaultDataLabelFormat.ShowPercentage = true;

        // Save the presentation
        try
        {
            presentation.Save("DoughnutChartWithLabels.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Handle format not supported or other save errors
        }
    }
}