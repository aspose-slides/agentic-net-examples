// -----------------------------------------------------------------------------
// Example: Apply treemap intensity color palette using C#
//
// Description:
// Demonstrates how to apply treemap intensity color palette using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Treemap, Intensity, 
// Color, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate apply treemap intensity color palette.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace TreemapIntensityExample
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

                // Add a Treemap chart
                IChart chart = slide.Shapes.AddChart(ChartType.Treemap, 50f, 50f, 500f, 400f);

                // Access the chart data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add a series
                IChartDataCell seriesNameCell = workbook.GetCell(0, 0, 0, "Sales");
                IChartSeries series = chart.ChartData.Series.Add(seriesNameCell, ChartType.Treemap);

                // Add categories (labels for treemap)
                IChartDataCell catCell1 = workbook.GetCell(0, 1, 0, "North");
                IChartDataCell catCell2 = workbook.GetCell(0, 2, 0, "South");
                IChartDataCell catCell3 = workbook.GetCell(0, 3, 0, "East");
                IChartDataCell catCell4 = workbook.GetCell(0, 4, 0, "West");
                chart.ChartData.Categories.Add(catCell1);
                chart.ChartData.Categories.Add(catCell2);
                chart.ChartData.Categories.Add(catCell3);
                chart.ChartData.Categories.Add(catCell4);

                // Define size values for each category
                double[] sizes = new double[] { 40, 20, 30, 10 };

                // Add data points with size values and apply color based on intensity
                for (int i = 0; i < sizes.Length; i++)
                {
                    IChartDataCell sizeCell = workbook.GetCell(0, i + 1, 1, sizes[i]);
                    IChartDataPoint dataPoint = series.DataPoints.AddDataPointForTreemapSeries(sizeCell);

                    // Calculate a color intensity (lighter to darker red)
                    int intensity = (int)(255 - (sizes[i] / 40.0) * 200); // range 55-255
                    Color pointColor = Color.FromArgb(255, intensity, 0, 0);

                    // Apply solid fill color
                    dataPoint.Format.Fill.SolidFillColor.Color = pointColor;
                }

                // Enable varied colors for the series (optional, ensures automatic variation if needed)
                series.ParentSeriesGroup.IsColorVaried = true;

                // Save the presentation
                try
                {
                    pres.Save("TreemapIntensity.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
                catch (ArgumentException ex)
                {
                    // Handle unsupported format exception
                    // Format not supported
                }
            }
        }
    }
}
