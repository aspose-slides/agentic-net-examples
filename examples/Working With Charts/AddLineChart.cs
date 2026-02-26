using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a line chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Line, 50, 50, 500, 400);

        // Clear default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Get the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Add categories (e.g., months)
        workbook.Clear(0);
        chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Jan"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Feb"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Mar"));

        // Add a series named "Sales"
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, "B1", "Sales"), chart.Type);

        // Add data points for the series
        series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, "B2", 100));
        series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, "B3", 150));
        series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, "B4", 130));

        // Save the presentation
        presentation.Save("LineChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}