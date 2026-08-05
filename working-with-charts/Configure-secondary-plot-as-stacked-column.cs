// -----------------------------------------------------------------------------
// Example: Configure secondary plot as stacked column using C#
//
// Description:
// Demonstrates how to configure a secondary plot as a stacked column while
// keeping the primary plot as a clustered column using C# and Aspose.Slides for
// .NET. The example shows the required presentation‑processing steps for
// PowerPoint files and produces the requested output in a standalone console
// application. Developers can use this pattern to automate PPTX workflows,
// validate results, or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Configure, Secondary, Plot,
// Stacked Column, Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate configuration of a secondary plot as stacked column.
// - Build C# tools for PowerPoint chart manipulation.
// - Generate or transform PPTX files with mixed chart types in .NET applications.
// - Validate chart configurations before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace ChartSecondaryPlotExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add a chart (primary plot as clustered column)
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 600f, 400f);

            // Clear default data
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get the chart data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Define default worksheet index
            int defaultWorksheetIndex = 0;

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

            // Add first series (primary)
            chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Primary Series"), chart.Type);
            IChartSeries primarySeries = chart.ChartData.Series[0];
            primarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 20));
            primarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 30));
            primarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 40));

            // Add second series (secondary)
            chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Secondary Series"), chart.Type);
            IChartSeries secondarySeries = chart.ChartData.Series[1];
            secondarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 15));
            secondarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 25));
            secondarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 35));

            // Plot the second series on secondary axis
            secondarySeries.PlotOnSecondAxis = true;

            // Configure chart types: primary remains clustered column, secondary becomes stacked column
            chart.Type = ChartType.ClusteredColumn;
            chart.SecondaryChartType = ChartType.StackedColumn;

            // Save the presentation
            string outputPath = "ChartSecondaryPlot.pptx";
            try
            {
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
        }
    }
}
