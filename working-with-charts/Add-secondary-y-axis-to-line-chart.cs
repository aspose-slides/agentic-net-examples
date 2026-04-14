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

        // Add a line chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 500, 400);

        // Clear any default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Get the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Add categories (e.g., months)
        chart.ChartData.Categories.Add(workbook.GetCell(0, 0, 1, "Jan"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 0, 2, "Feb"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 0, 3, "Mar"));

        // Add first series (plotted on primary Y‑axis)
        Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series.Add(workbook.GetCell(0, 1, 0, "Series 1"), chart.Type);
        series1.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 1, 10));
        series1.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 2, 20));
        series1.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 3, 30));

        // Add second series (plotted on secondary Y‑axis)
        Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(0, 2, 0, "Series 2"), chart.Type);
        series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 1, 100));
        series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 2, 200));
        series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 3, 300));

        // Enable secondary axis for the second series
        series2.PlotOnSecondAxis = true;

        // Optionally set titles for axes
        chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("Primary Axis");
        chart.Axes.SecondaryVerticalAxis.Title.AddTextFrameForOverriding("Secondary Axis");

        // Save the presentation
        presentation.Save("LineChartWithSecondaryAxis.pptx", SaveFormat.Pptx);

        // Clean up
        presentation.Dispose();
    }
}