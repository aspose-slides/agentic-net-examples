// -----------------------------------------------------------------------------
// Example: Insert radar chart with polygon fill opacity using C#
//
// Description:
// Demonstrates how to insert a radar chart with a semi‑transparent polygon (plot area) fill using C# 
// and Aspose.Slides for .NET. The example creates a new presentation, adds a radar chart,
// populates it with series and categories, applies a 50% opacity fill to the chart's plot area,
// and saves the result as a PPTX file. This pattern can be used to automate PowerPoint
// chart creation and styling in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Insert, Radar, Chart, Polygon, Fill, Opacity, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate insertion of radar charts with custom semi‑transparent plot area fills.
// - Build C# utilities for PowerPoint presentation generation and styling.
// - Generate or transform PPTX files with specific chart visual requirements in .NET.
// - Validate and preview chart appearance programmatically before publishing.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

namespace InsertRadarChart
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Add a radar chart
                IChart chart = slide.Shapes.AddChart(ChartType.Radar, 50, 50, 500, 400);

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Get the chart data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Add series
                IChartSeries series1 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);
                IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category A"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category B"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category C"));

                // Populate series data
                series1.DataPoints.AddDataPointForRadarSeries(workbook.GetCell(0, 1, 1, 4));
                series1.DataPoints.AddDataPointForRadarSeries(workbook.GetCell(0, 2, 1, 7));
                series1.DataPoints.AddDataPointForRadarSeries(workbook.GetCell(0, 3, 1, 5));

                series2.DataPoints.AddDataPointForRadarSeries(workbook.GetCell(0, 1, 2, 6));
                series2.DataPoints.AddDataPointForRadarSeries(workbook.GetCell(0, 2, 2, 3));
                series2.DataPoints.AddDataPointForRadarSeries(workbook.GetCell(0, 3, 2, 8));

                // Customize polygon (plot area) fill with semi‑transparent color
                chart.PlotArea.Format.Fill.FillType = FillType.Solid;
                chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.FromArgb(128, Color.LightGray); // 50% opacity

                // Save the presentation
                try
                {
                    pres.Save("RadarChartWithOpacity.pptx", SaveFormat.Pptx);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                }
                catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
                {
                    // Handle file I/O errors
                }
            }
        }
    }
}
