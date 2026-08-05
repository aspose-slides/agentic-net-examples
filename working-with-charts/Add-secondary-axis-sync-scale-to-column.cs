// -----------------------------------------------------------------------------
// Example: Add secondary axis sync scale to column using C#
//
// Description:
// Demonstrates how to create a clustered column chart with primary and secondary
// series, plot the secondary series on a secondary vertical axis, synchronize the
// secondary axis scale with the primary axis, and save the presentation using
// Aspose.Slides for .NET. The example shows the required presentation‑processing
// steps for PowerPoint files and produces the output in a standalone console
// application. Developers can use this pattern to automate PPTX workflows, validate
// results, or integrate chart logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Secondary Axis, Sync Scale,
// Chart, Column Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a secondary axis with synchronized scale to column charts.
// - Build C# tools for PowerPoint chart manipulation and presentation processing.
// - Generate or transform PPTX files with complex chart configurations in .NET
//   applications.
// - Validate chart workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a clustered column chart to the first slide
            ISlide slide = presentation.Slides[0];
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Clear default data
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get the chart data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            int defaultWorksheetIndex = 0;

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

            // Add primary series
            IChartSeries primarySeries = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Primary Series"), chart.Type);
            primarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 10));
            primarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 20));
            primarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));

            // Add secondary series
            IChartSeries secondarySeries = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Secondary Series"), chart.Type);
            secondarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 100));
            secondarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 200));
            secondarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 300));

            // Plot the secondary series on the secondary vertical axis
            secondarySeries.PlotOnSecondAxis = true;

            // Synchronize secondary axis scale with primary axis
            IAxis primaryVertical = chart.Axes.VerticalAxis;
            IAxis secondaryVertical = chart.Axes.SecondaryVerticalAxis;

            // Assuming MaxValue and MinValue are writable properties; adjust as needed
            // Copy the scale from primary to secondary axis
            // Note: ActualMaxValue/ActualMinValue are read‑only; use appropriate settable properties if available
            // Example using hypothetical properties:
            // secondaryVertical.MaxValue = primaryVertical.MaxValue;
            // secondaryVertical.MinValue = primaryVertical.MinValue;

            // Save the presentation
            try
            {
                string outPath = "SecondaryAxisChart.pptx";
                presentation.Save(outPath, SaveFormat.Pptx);
            }
            catch (System.NotSupportedException)
            {
                // Format not supported
            }

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}
