using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

public class Program
{
    public static void Main()
    {
        // Define data directory
        string dataDir = "Data";
        Directory.CreateDirectory(dataDir);

        // Define workbook path
        string workbookPath = Path.Combine(dataDir, "workbook.xlsx");

        // Create an empty workbook file if it does not exist
        if (!File.Exists(workbookPath))
        {
            File.WriteAllBytes(workbookPath, new byte[0]);
        }

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a pie chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Pie, 50, 50, 400, 600);

        // Get the chart data object
        Aspose.Slides.Charts.IChartData chartData = chart.ChartData;

        // Set the external workbook as the data source for the chart
        ((Aspose.Slides.Charts.ChartData)chartData).SetExternalWorkbook(workbookPath);

        // Add a series to the chart
        chartData.Series.Add(
            chartData.ChartDataWorkbook.GetCell(0, "A1", "Series 1"),
            Aspose.Slides.Charts.ChartType.Pie);

        // Add data points for the series
        chartData.Series[0].DataPoints.AddDataPointForPieSeries(
            chartData.ChartDataWorkbook.GetCell(0, "B1", 10));
        chartData.Series[0].DataPoints.AddDataPointForPieSeries(
            chartData.ChartDataWorkbook.GetCell(0, "B2", 20));
        chartData.Series[0].DataPoints.AddDataPointForPieSeries(
            chartData.ChartDataWorkbook.GetCell(0, "B3", 30));

        // Add categories to the chart
        chartData.Categories.Add(
            chartData.ChartDataWorkbook.GetCell(0, "A2", "Category A"));
        chartData.Categories.Add(
            chartData.ChartDataWorkbook.GetCell(0, "A3", "Category B"));
        chartData.Categories.Add(
            chartData.ChartDataWorkbook.GetCell(0, "A4", "Category C"));

        // Save the presentation
        string outputPath = Path.Combine(dataDir, "ExternalWorkbookChart.pptx");
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}