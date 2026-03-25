using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the existing presentation
        Presentation pres = new Presentation(inputPath);

        // Access the first slide
        ISlide slide = pres.Slides[0];

        // Add a clustered column chart
        IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 600, 400);

        // Clear any default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Get the chart data workbook
        IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
        int defaultWorksheetIndex = 0;

        // Add categories
        IChartCategory category1 = chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, "C2", "Category 1"));
        IChartCategory category2 = chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, "C3", "Category 2"));
        IChartCategory category3 = chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, "C4", "Category 3"));

        // Add series
        IChartSeries series1 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, "D1", "Series 1"), ChartType.ClusteredColumn);
        IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, "D2", "Series 2"), ChartType.ClusteredColumn);

        // Populate data points for the first series
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "D2", 20));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "D3", 50));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "D4", 30));

        // Populate data points for the second series
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "E2", 30));
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "E3", 10));
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "E4", 60));

        // Save the updated presentation
        pres.Save(outputPath, SaveFormat.Pptx);
    }
}