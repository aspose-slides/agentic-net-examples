// -----------------------------------------------------------------------------
// Example: Create treemap chart with intensity palette using C#
//
// Description:
// Demonstrates how to create a treemap chart with an intensity‑based color
// palette using C# and Aspose.Slides for .NET. The example builds a presentation,
// adds a treemap chart, defines hierarchical categories, assigns size values to
// leaf nodes, and applies a red gradient fill that reflects the intensity of each
// value. The resulting PPTX file can be used to visualize hierarchical data with
// color‑coded intensity.
//
// Keywords:
// C#, Aspose.Slides for .NET, PowerPoint, PPTX, Treemap chart, Intensity palette,
// Chart color gradient, Presentation automation, Office automation
//
// Use Cases:
// - Generate treemap charts with intensity‑driven colors for business reports.
// - Automate creation of hierarchical visualizations in PowerPoint via .NET.
// - Build C# utilities that process and enrich PPTX files with custom chart data.
// - Validate chart rendering and color mapping before publishing presentations.
// -----------------------------------------------------------------------------

using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace TreemapChartExample
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

                // Add a treemap chart
                IChart chart = slide.Shapes.AddChart(ChartType.Treemap, 50f, 50f, 500f, 400f);

                // Clear default categories and series
                chart.ChartData.Categories.Clear();
                chart.ChartData.Series.Clear();

                // Get the chart data workbook
                IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;
                wb.Clear(0);

                // Add categories with grouping (two branches, each with two leaves)
                IChartCategory leaf;

                // Branch 1 - Stem
                leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C1", "Branch1"));
                leaf.GroupingLevels.SetGroupingItem(0, "Branch1");

                // Leaf 1 under Branch 1
                leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C2", "Leaf1"));
                leaf.GroupingLevels.SetGroupingItem(0, "Branch1");
                leaf.GroupingLevels.SetGroupingItem(1, "Leaf1");

                // Leaf 2 under Branch 1
                leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C3", "Leaf2"));
                leaf.GroupingLevels.SetGroupingItem(0, "Branch1");
                leaf.GroupingLevels.SetGroupingItem(1, "Leaf2");

                // Branch 2 - Stem
                leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C4", "Branch2"));
                leaf.GroupingLevels.SetGroupingItem(0, "Branch2");

                // Leaf 3 under Branch 2
                leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C5", "Leaf3"));
                leaf.GroupingLevels.SetGroupingItem(0, "Branch2");
                leaf.GroupingLevels.SetGroupingItem(1, "Leaf3");

                // Leaf 4 under Branch 2
                leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C6", "Leaf4"));
                leaf.GroupingLevels.SetGroupingItem(0, "Branch2");
                leaf.GroupingLevels.SetGroupingItem(1, "Leaf4");

                // Add a series for the treemap
                IChartSeries series = chart.ChartData.Series.Add(ChartType.Treemap);
                series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

                // Define size values for each leaf (intensity)
                double[] sizeValues = new double[] { 10, 30, 50, 70, 90, 110 };
                // Add data points and apply color based on intensity
                for (int i = 0; i < sizeValues.Length; i++)
                {
                    IChartDataCell cell = wb.GetCell(0, $"D{i + 1}", sizeValues[i]);
                    IChartDataPoint dp = series.DataPoints.AddDataPointForTreemapSeries(cell);

                    // Calculate color intensity (red gradient)
                    int intensity = (int)Math.Min(255, sizeValues[i] * 2);
                    dp.Format.Fill.FillType = FillType.Solid;
                    dp.Format.Fill.SolidFillColor.Color = Color.FromArgb(255, intensity, 0, 0);
                }

                // Set parent label layout
                series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

                // Save the presentation
                pres.Save("TreemapChart.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
