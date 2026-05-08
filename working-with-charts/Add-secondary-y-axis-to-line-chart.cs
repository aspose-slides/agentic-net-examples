using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a line chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Line, 50, 50, 500, 400);

        // Access the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Clear default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Add categories
        chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Jan"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Feb"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Mar"));

        // Add first series (primary axis)
        Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);
        series1.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 1, 10));
        series1.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 1, 20));
        series1.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 1, 30));

        // Add second series (secondary axis)
        Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);
        series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 2, 100));
        series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 2, 200));
        series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 2, 300));

        // Plot second series on secondary axis
        series2.PlotOnSecondAxis = true;

        // Optionally set title for secondary vertical axis
        chart.Axes.SecondaryVerticalAxis.Title.AddTextFrameForOverriding("Secondary Axis");

        // Save the presentation
        try
        {
            presentation.Save("LineChartWithSecondaryAxis.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported or other save errors
        }
        finally
        {
            presentation.Dispose();
        }
    }
}