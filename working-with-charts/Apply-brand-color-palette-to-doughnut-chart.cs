// -----------------------------------------------------------------------------
// Example: Apply brand color palette to doughnut chart using C#
//
// Description:
// Demonstrates how to apply a brand color palette to a doughnut chart using C# 
// and Aspose.Slides for .NET. The example shows the required presentation‑processing 
// steps for PowerPoint files and produces the requested output in a standalone 
// console application. Developers can use this pattern to automate PPTX workflows, 
// validate results, or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Brand, Color, Palette, 
// Doughnut Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate applying a brand color palette to a doughnut chart.
// - Build C# tools for PowerPoint presentation processing with custom chart colors.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ApplyBrandColorPaletteToDoughnutChart
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation pres = new Presentation();

                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a doughnut chart
                IChart chart = slide.Shapes.AddChart(
                    ChartType.Doughnut,
                    50f, 50f, 400f, 400f);

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Get the chart data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                int defaultWorksheetIndex = 0;

                // Add a series
                IChartSeries series = chart.ChartData.Series.Add(
                    workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"),
                    ChartType.Doughnut);

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category A"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category B"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category C"));

                // Add data points for the doughnut series
                series.DataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 30));
                series.DataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 50));
                series.DataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 20));

                // Define corporate brand colors
                Color[] brandColors = new Color[]
                {
                    Color.FromArgb(0x00, 0x7A, 0xCC), // Brand Blue
                    Color.FromArgb(0xFF, 0xC0, 0x00), // Brand Gold
                    Color.FromArgb(0x00, 0x99, 0x33)  // Brand Green
                };

                // Apply brand colors to each data point
                for (int i = 0; i < series.DataPoints.Count; i++)
                {
                    IChartDataPoint point = series.DataPoints[i];
                    point.Format.Fill.FillType = FillType.Solid;
                    point.Format.Fill.SolidFillColor.Color = brandColors[i % brandColors.Length];
                }

                // Save the presentation
                pres.Save("BrandDoughnutChart.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle any errors (e.g., file I/O, unsupported format)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
