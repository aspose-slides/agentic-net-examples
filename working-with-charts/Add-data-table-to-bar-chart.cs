// -----------------------------------------------------------------------------
// Example: Add data table to clustered column chart using C#
//
// Description:
// Demonstrates how to add a data table beneath a clustered column (bar) chart
// using C# and Aspose.Slides for .NET. The example creates a new presentation,
// inserts a chart, populates categories and a series, enables the data table,
// and saves the result as a PPTX file. This pattern can be used to automate
// chart enhancements in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Data Table, Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding data tables to bar/column charts.
// - Build .NET tools for enhancing PowerPoint presentations.
// - Generate or modify PPTX files with chart data tables.
// - Validate chart rendering in automated workflows.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add a clustered column (bar) chart to the first slide
        Aspose.Slides.Charts.IChart chart = pres.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 100, 100, 600, 400);
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Get the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
        int defaultWorksheetIndex = 0;

        // Add categories
        Aspose.Slides.Charts.IChartCategory category;
        category = chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Category A"));
        category = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Category B"));
        category = chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Category C"));
        category = chart.ChartData.Categories.Add(workbook.GetCell(0, "C5", "Category D"));
        category = chart.ChartData.Categories.Add(workbook.GetCell(0, "C6", "Category E"));
        category = chart.ChartData.Categories.Add(workbook.GetCell(0, "C7", "Category F"));
        category = chart.ChartData.Categories.Add(workbook.GetCell(0, "C8", "Category G"));
        category = chart.ChartData.Categories.Add(workbook.GetCell(0, "C9", "Category H"));

        // Add a series and populate data points
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
            workbook.GetCell(0, "D1", "Series 1"), Aspose.Slides.Charts.ChartType.ClusteredColumn);
        series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "D2", 10));
        series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "D3", 20));
        series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "D4", 30));
        series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "D5", 40));
        series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "D6", 50));
        series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "D7", 60));
        series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "D8", 70));
        series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, "D9", 80));

        // Enable the data table beneath the chart
        chart.HasDataTable = true;

        // Save the presentation
        string outputPath = "BarChartWithDataTable.pptx";
        try
        {
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions such as unsupported format or I/O errors
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
    }
}
