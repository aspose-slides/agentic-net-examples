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
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a pie chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);

        // Get the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Clear default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Add a new series
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

        // Add categories
        chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category A"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category B"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category C"));

        // Add data points for the pie series
        series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 1, 1, 30));
        series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 2, 1, 50));
        series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 3, 1, 20));

        // Set each slice to use automatic colors (no explicit fill)
        foreach (Aspose.Slides.Charts.IChartDataPoint point in series.DataPoints)
        {
            point.Format.Fill.FillType = FillType.NotDefined;
        }

        // Save the presentation
        pres.Save("AutomaticPieColors_out.pptx", SaveFormat.Pptx);

        // Clean up
        pres.Dispose();
    }
}