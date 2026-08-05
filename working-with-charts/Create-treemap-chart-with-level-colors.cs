// -----------------------------------------------------------------------------
// Example: Create treemap chart with hierarchical level colors using C#
//
// Description:
// Demonstrates how to create a Treemap chart with custom colors for each
// hierarchical level, define grouping levels for leaf categories, and set a
// parent label layout using Aspose.Slides for .NET. The example builds a
// presentation from scratch, adds a Treemap chart, populates categories and
// series, applies solid fill colors per level, and saves the result as a PPTX
// file. This pattern can be used in console applications or integrated into
// larger .NET solutions for automated PowerPoint generation.
//
// Keywords:
// C#, .NET, PowerPoint, PPTX, Aspose.Slides, Aspose.Slides.Charts, Treemap,
// Chart, Hierarchical Levels, Level Colors, Grouping, ParentLabelLayout,
// FillType, Presentation Automation, Office Automation
//
// Use Cases:
// - Generate Treemap charts with distinct colors per hierarchy level.
// - Automate PowerPoint creation that requires grouped categories.
// - Build C# utilities for customizing chart appearance in PPTX files.
// - Validate and test presentation workflows involving Treemap charts.
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

                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Add a Treemap chart
                IChart chart = slide.Shapes.AddChart(ChartType.Treemap, 50, 50, 500, 400);

                // Clear default categories and series
                chart.ChartData.Categories.Clear();
                chart.ChartData.Series.Clear();

                // Get the chart data workbook
                IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;
                wb.Clear(0);

                // Add categories (leaves) with grouping
                IChartCategory leaf;

                leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C1", "Leaf 1"));
                leaf.GroupingLevels.SetGroupingItem(0, "Stem 1");
                leaf.GroupingLevels.SetGroupingItem(1, "Branch 1");

                chart.ChartData.Categories.Add(wb.GetCell(0, "C2", "Leaf 2"));

                leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C3", "Leaf 3"));
                leaf.GroupingLevels.SetGroupingItem(0, "Stem 2");

                chart.ChartData.Categories.Add(wb.GetCell(0, "C4", "Leaf 4"));

                leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C5", "Leaf 5"));
                leaf.GroupingLevels.SetGroupingItem(0, "Stem 3");
                leaf.GroupingLevels.SetGroupingItem(1, "Branch 2");

                chart.ChartData.Categories.Add(wb.GetCell(0, "C6", "Leaf 6"));

                leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C7", "Leaf 7"));
                leaf.GroupingLevels.SetGroupingItem(0, "Stem 4");

                chart.ChartData.Categories.Add(wb.GetCell(0, "C8", "Leaf 8"));

                // Add a series
                IChartSeries series = chart.ChartData.Series.Add(ChartType.Treemap);
                series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

                // Add data points for the series
                series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D1", 10));
                series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D2", 20));
                series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D3", 30));
                series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D4", 40));
                series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D5", 50));
                series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D6", 60));
                series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D7", 70));
                series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D8", 80));

                // Set parent label layout
                series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

                // Assign distinct colors to each hierarchical level
                // Level 0 - Red, Level 1 - Green, Level 2 - Blue
                Color[] levelColors = new Color[] { Color.Red, Color.Green, Color.Blue };
                for (int i = 0; i < series.DataPoints.Count; i++)
                {
                    IChartDataPoint point = series.DataPoints[i];
                    for (int level = 0; level < point.DataPointLevels.Count; level++)
                    {
                        IChartDataPointLevel dpLevel = point.DataPointLevels[level];
                        dpLevel.Format.Fill.FillType = FillType.Solid;
                        dpLevel.Format.Fill.SolidFillColor.Color = levelColors[level % levelColors.Length];
                    }
                }

                // Save the presentation
                pres.Save("TreemapChart.pptx", SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file I/O, Aspose.Slides errors)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
