// -----------------------------------------------------------------------------
// Example: Add secondary axis to column chart synchronize using C#
//
// Description:
// Demonstrates how to add a secondary vertical axis to a clustered column chart
// and synchronize its scale with the primary vertical axis using C# and
// Aspose.Slides for .NET. The example creates a new presentation, builds chart
// data, configures the secondary axis, and saves the result as a PPTX file.
// Developers can use this pattern to automate chart creation and axis
// synchronization in PowerPoint presentations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Secondary Axis, Column Chart,
// Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a secondary axis to column charts and synchronizing scales.
// - Build C# tools for PowerPoint chart manipulation and presentation processing.
// - Generate or transform PPTX files with synchronized chart axes in .NET applications.
// - Validate chart configurations before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        using (Presentation pres = new Presentation())
        {
            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a clustered column chart without sample data
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f, false);

            // Clear any default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get the chart data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            int defaultWorksheetIndex = 0;

            // Add primary series
            IChartSeries primarySeries = chart.ChartData.Series.Add(
                workbook.GetCell(defaultWorksheetIndex, 0, 1, "Primary Series"),
                ChartType.ClusteredColumn);

            // Add secondary series and plot it on the secondary axis
            IChartSeries secondarySeries = chart.ChartData.Series.Add(
                workbook.GetCell(defaultWorksheetIndex, 0, 2, "Secondary Series"),
                ChartType.ClusteredColumn);
            secondarySeries.PlotOnSecondAxis = true;

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

            // Populate primary series data points
            primarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 20.0));
            primarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 40.0));
            primarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30.0));

            // Populate secondary series data points
            secondarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 200.0));
            secondarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 150.0));
            secondarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 180.0));

            // Synchronize secondary vertical axis scale with primary vertical axis
            IAxis primaryAxis = chart.Axes.VerticalAxis;
            IAxis secondaryAxis = chart.Axes.SecondaryVerticalAxis;
            if (secondaryAxis != null)
            {
                secondaryAxis.MinValue = primaryAxis.MinValue;
                secondaryAxis.MaxValue = primaryAxis.MaxValue;
            }

            // Save the presentation
            pres.Save("AddSecondaryAxis.pptx", SaveFormat.Pptx);
        }
    }
}
