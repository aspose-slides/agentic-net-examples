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
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

        // Remove default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Get the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Clear the workbook (optional, ensures a clean start)
        workbook.Clear(0);

        // Add categories
        chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));

        // Add a series
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, "B0", "Series 1"), chart.Type);

        // Add data points to the series
        series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, "B1", 20));
        series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, "B2", 50));
        series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, "B3", 30));

        // Show the value for the second data point (index 1)
        Aspose.Slides.Charts.IDataLabel dataLabel = series.DataPoints[1].Label;
        dataLabel.DataLabelFormat.ShowValue = true;

        // Save the presentation
        presentation.Save("ShowDataPointValue.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}