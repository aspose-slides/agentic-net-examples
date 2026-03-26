using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.IO;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation pres = new Presentation();

        // Add a clustered column chart on the first slide
        IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100f, 100f, 600f, 400f);

        // Clear default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Get the chart data workbook
        IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
        int defaultWorksheetIndex = 0;

        // Add categories with grouping
        IChartCategory category;
        category = chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, "C2", "A"));
        category.GroupingLevels.SetGroupingItem(1, "Group1");
        category = chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, "C3", "B"));
        category = chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, "C4", "C"));
        category.GroupingLevels.SetGroupingItem(1, "Group2");
        category = chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, "C5", "D"));
        category = chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, "C6", "E"));
        category.GroupingLevels.SetGroupingItem(1, "Group3");
        category = chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, "C7", "F"));
        category = chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, "C8", "G"));
        category.GroupingLevels.SetGroupingItem(1, "Group4");
        category = chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, "C9", "H"));

        // Add a series
        IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, "D1", "Series 1"), ChartType.ClusteredColumn);

        // Populate series data points
        series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "D2", 10));
        series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "D3", 20));
        series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "D4", 30));
        series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "D5", 40));
        series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "D6", 50));
        series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "D7", 60));
        series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "D8", 70));
        series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "D9", 80));

        // Save the presentation
        string outputPath = "UpdatedChart.pptx";
        pres.Save(outputPath, SaveFormat.Pptx);
    }
}