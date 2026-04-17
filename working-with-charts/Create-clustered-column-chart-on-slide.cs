using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

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
            0f, 0f, 500f, 400f);

        // Remove default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Get the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Add categories
        chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

        // Add series
        chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);
        chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);

        // Populate data for Series 1
        Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series[0];
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 20));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 50));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 30));

        // Populate data for Series 2
        Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series[1];
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 30));
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 10));
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 2, 60));

        // Save the presentation
        try
        {
            presentation.Save("ClusteredColumnChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other save errors
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
    }
}