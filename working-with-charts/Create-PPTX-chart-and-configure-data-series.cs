using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define output file path
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "ChartOutput.pptx");

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

        // Get the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Clear default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Add categories
        Aspose.Slides.Charts.IChartDataCell catCell1 = workbook.GetCell(0, 1, 0, "Category 1");
        Aspose.Slides.Charts.IChartDataCell catCell2 = workbook.GetCell(0, 2, 0, "Category 2");
        Aspose.Slides.Charts.IChartDataCell catCell3 = workbook.GetCell(0, 3, 0, "Category 3");
        chart.ChartData.Categories.Add(catCell1);
        chart.ChartData.Categories.Add(catCell2);
        chart.ChartData.Categories.Add(catCell3);

        // Add first series and its data points
        Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series.Add(
            workbook.GetCell(0, 0, 1, "Series 1"), Aspose.Slides.Charts.ChartType.ClusteredColumn);
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 10));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 20));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 30));

        // Add second series and its data points
        Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series.Add(
            workbook.GetCell(0, 0, 2, "Series 2"), Aspose.Slides.Charts.ChartType.ClusteredColumn);
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 15));
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 25));
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 2, 35));

        // Save the presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}