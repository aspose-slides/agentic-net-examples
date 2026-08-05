// -----------------------------------------------------------------------------
// Example: Add multi level category axis to column chart using C#
//
// Description:
// Demonstrates how to add a multi‑level category axis to a clustered column chart
// using C# and Aspose.Slides for .NET. The example creates a new presentation,
// builds a column chart with hierarchical categories (Region → Country), populates
// it with data, and saves the result as a PPTX file. This pattern can be used to
// automate PowerPoint chart creation, integrate chart logic into .NET applications,
// or validate presentation workflows.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Multi‑Level Category Axis, Chart,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding multi‑level category axes to column charts.
// - Build C# tools for PowerPoint chart generation and manipulation.
// - Generate or transform PPTX files with hierarchical chart categories.
// - Validate chart creation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            var pres = new Presentation();

            // Access the first slide
            var slide = pres.Slides[0];

            // Add a clustered column chart
            var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Clear default categories and series
            chart.ChartData.Categories.Clear();
            chart.ChartData.Series.Clear();

            // Get the chart data workbook
            var wb = chart.ChartData.ChartDataWorkbook;
            wb.Clear(0);

            // Add multi-level categories
            // Category: Region -> Country
            var leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C2", "USA"));
            leaf.GroupingLevels.SetGroupingItem(0, "North America");
            leaf.GroupingLevels.SetGroupingItem(1, "USA");

            leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C3", "Canada"));
            leaf.GroupingLevels.SetGroupingItem(0, "North America");
            leaf.GroupingLevels.SetGroupingItem(1, "Canada");

            leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C4", "Germany"));
            leaf.GroupingLevels.SetGroupingItem(0, "Europe");
            leaf.GroupingLevels.SetGroupingItem(1, "Germany");

            leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C5", "France"));
            leaf.GroupingLevels.SetGroupingItem(0, "Europe");
            leaf.GroupingLevels.SetGroupingItem(1, "France");

            // Add a series
            var series = chart.ChartData.Series.Add(wb.GetCell(0, "D1", "Sales"), chart.Type);
            series.DataPoints.AddDataPointForBarSeries(wb.GetCell(0, "D2", 12000));
            series.DataPoints.AddDataPointForBarSeries(wb.GetCell(0, "D3", 15000));
            series.DataPoints.AddDataPointForBarSeries(wb.GetCell(0, "D4", 18000));
            series.DataPoints.AddDataPointForBarSeries(wb.GetCell(0, "D5", 13000));

            // Save the presentation
            pres.Save("MultiLevelCategoryChart.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
