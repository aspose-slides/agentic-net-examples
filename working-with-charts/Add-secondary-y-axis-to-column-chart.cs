// -----------------------------------------------------------------------------
// Example: Add secondary y axis to column chart using C#
//
// Description:
// Demonstrates how to add a secondary Y axis to a clustered column chart using
// C# and Aspose.Slides for .NET. The example creates a new presentation,
// inserts a column chart, populates it with two product series, assigns the
// second series to the secondary vertical axis, sets axis titles, and saves
// the result as a PPTX file. This pattern can be used to automate chart
// enhancements in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Secondary, Axis, Column, Chart,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a secondary Y axis to column charts.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files with advanced chart configurations.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using Aspose.Slides.Export;
using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
        {
            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a clustered column chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Set chart title (use AddTextFrameForOverriding, not Text property)
            chart.ChartTitle.AddTextFrameForOverriding("Sales Comparison");
            chart.HasTitle = true;

            // Get the chart data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            int defaultWorksheetIndex = 0;

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Q1"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Q2"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Q3"));

            // Add first series
            Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series.Add(
                workbook.GetCell(defaultWorksheetIndex, 0, 1, "Product A"), chart.Type);
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 20));
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 50));
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));
            series1.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
            series1.Format.Fill.SolidFillColor.Color = Color.Red;

            // Add second series
            Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series.Add(
                workbook.GetCell(defaultWorksheetIndex, 0, 2, "Product B"), chart.Type);
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 30));
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 10));
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 60));
            series2.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
            series2.Format.Fill.SolidFillColor.Color = Color.Green;

            // Plot the second series on the secondary vertical axis
            series2.PlotOnSecondAxis = true;

            // Optionally set a title for the secondary axis
            Aspose.Slides.Charts.IAxis secondaryAxis = chart.Axes.SecondaryVerticalAxis;
            secondaryAxis.Title.AddTextFrameForOverriding("Secondary Axis");

            // Save the presentation
            pres.Save("AddSecondaryYAxis.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
