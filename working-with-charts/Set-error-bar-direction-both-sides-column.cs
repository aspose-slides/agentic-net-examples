// -----------------------------------------------------------------------------
// Example: Set error bar direction both sides column using C#
//
// Description:
// Demonstrates how to set error bar direction to both positive and negative
// sides for a clustered column chart using C# and Aspose.Slides for .NET.
// The example creates a new presentation, adds a column chart, populates it
// with categories, a series, and data points, configures error bars to show
// both directions, and saves the result as a PPTX file. Developers can use
// this pattern to automate PowerPoint chart error‑bar configuration in .NET
// applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Error Bar, Both Sides, Column
// Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting error bar direction to both sides for column charts.
// - Build C# tools for PowerPoint chart customization and processing.
// - Generate or transform PPTX files with specific chart error‑bar settings.
// - Validate presentation workflows involving chart error bars before publishing.
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
            Presentation presentation = new Presentation();
            ISlide slide = presentation.Slides[0];

            // Add a clustered column chart
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(0, 0, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 0, 1, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 0, 2, "Category 3"));

            // Add a series
            chart.ChartData.Series.Add(workbook.GetCell(0, 1, 0, "Series 1"), chart.Type);
            IChartSeries series = chart.ChartData.Series[0];

            // Add data points
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 10));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 20));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 3, 15));

            // Set error bars to show both positive and negative directions
            series.ErrorBarsYFormat.Type = ErrorBarType.Both;
            series.ErrorBarsYFormat.IsVisible = true;

            // Save the presentation
            presentation.Save("ColumnChartWithErrorBars.pptx", SaveFormat.Pptx);
        }
        catch (System.IO.FileNotFoundException ex)
        {
            // Handle missing input file
            Console.WriteLine("Input file not found: " + ex.Message);
        }
        catch (NotSupportedException)
        {
            // format not supported
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
