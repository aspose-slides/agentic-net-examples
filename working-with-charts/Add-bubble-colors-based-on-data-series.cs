// -----------------------------------------------------------------------------
// Example: Add bubble colors based on data series using C#
//
// Description:
// Demonstrates how to create a bubble chart, populate it with X, Y, and size
// values, and assign individual colors to each bubble based on its data series
// using Aspose.Slides for .NET. The example shows the required presentation-
// processing steps for PowerPoint files and produces a PPTX file in a standalone
// console application. Developers can use this pattern to automate PPTX workflows,
// validate results, or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Bubble, Colors, Data Series,
// Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding colored bubbles to a chart based on data series.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files with customized bubble charts in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace BubbleChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a bubble chart to the first slide
            IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50f, 50f, 600f, 400f);

            // Set bubble size representation to Width
            chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;

            // Optionally set bubble size scaling (e.g., 150%)
            chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;

            // Access the chart's workbook to add data
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Clear any default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add a series for bubble data
            IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

            // Add data points (X, Y, Size) and assign colors
            IChartDataPoint point1 = series.DataPoints.AddDataPointForBubbleSeries(
                workbook.GetCell(0, 1, 1, 10),   // X value
                workbook.GetCell(0, 1, 2, 20),   // Y value
                workbook.GetCell(0, 1, 3, 30));  // Bubble size
            point1.Format.Fill.FillType = FillType.Solid;
            point1.Format.Fill.SolidFillColor.Color = Color.Red;

            IChartDataPoint point2 = series.DataPoints.AddDataPointForBubbleSeries(
                workbook.GetCell(0, 2, 1, 15),
                workbook.GetCell(0, 2, 2, 25),
                workbook.GetCell(0, 2, 3, 40));
            point2.Format.Fill.FillType = FillType.Solid;
            point2.Format.Fill.SolidFillColor.Color = Color.Green;

            IChartDataPoint point3 = series.DataPoints.AddDataPointForBubbleSeries(
                workbook.GetCell(0, 3, 1, 20),
                workbook.GetCell(0, 3, 2, 30),
                workbook.GetCell(0, 3, 3, 50));
            point3.Format.Fill.FillType = FillType.Solid;
            point3.Format.Fill.SolidFillColor.Color = Color.Blue;

            // Save the presentation
            string outputPath = "BubbleChartWithColors.pptx";
            try
            {
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex) when (ex is NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
            }
        }
    }
}
