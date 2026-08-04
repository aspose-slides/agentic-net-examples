// -----------------------------------------------------------------------------
// Example: Replace all charts with treemap using C#
//
// Description:
// Demonstrates how to replace every chart in a PowerPoint presentation with a
// treemap chart using C# and Aspose.Slides for .NET. The example loads an
// existing PPTX (or creates a new one if the source is missing), iterates over
// all slides and shapes, replaces each chart while preserving its position and
// size, populates the treemap with sample hierarchical data, and saves the
// modified presentation. This pattern can be used to automate PPTX workflows,
// transform chart types, or integrate presentation processing into .NET
// applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Replace, Charts, Treemap,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate replacement of all charts with treemap visualizations.
// - Build C# tools for PowerPoint presentation transformation.
// - Generate or modify PPTX files programmatically in .NET applications.
// - Validate and standardize chart types before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ReplaceChartsWithTreemap
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = args.Length > 1 ? args[1] : "output.pptx";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                // Create a new empty presentation if source does not exist
                using (Presentation emptyPres = new Presentation())
                {
                    emptyPres.Save(outputPath, SaveFormat.Pptx);
                }
                return;
            }

            try
            {
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        ISlide slide = pres.Slides[slideIndex];

                        // Iterate backwards to safely remove shapes
                        for (int shapeIndex = slide.Shapes.Count - 1; shapeIndex >= 0; shapeIndex--)
                        {
                            IChart existingChart = slide.Shapes[shapeIndex] as IChart;
                            if (existingChart != null)
                            {
                                // Preserve position and size
                                float chartX = existingChart.X;
                                float chartY = existingChart.Y;
                                float chartWidth = existingChart.Width;
                                float chartHeight = existingChart.Height;

                                // Remove the existing chart
                                slide.Shapes.RemoveAt(shapeIndex);

                                // Add a new Treemap chart (using the tree-map-chart rule)
                                IChart treemapChart = slide.Shapes.AddChart(ChartType.Treemap, chartX, chartY, chartWidth, chartHeight);
                                treemapChart.ChartData.Categories.Clear();
                                treemapChart.ChartData.Series.Clear();

                                IChartDataWorkbook wb = treemapChart.ChartData.ChartDataWorkbook;
                                wb.Clear(0);

                                // Branch 1
                                IChartCategory leaf = treemapChart.ChartData.Categories.Add(wb.GetCell(0, "C1", "Leaf 1"));
                                leaf.GroupingLevels.SetGroupingItem(0, "Stem 1");
                                leaf.GroupingLevels.SetGroupingItem(1, "Branch 1");
                                treemapChart.ChartData.Categories.Add(wb.GetCell(0, "C2", "Leaf 2"));
                                leaf = treemapChart.ChartData.Categories.Add(wb.GetCell(0, "C3", "Leaf 3"));
                                leaf.GroupingLevels.SetGroupingItem(0, "Stem 2");
                                treemapChart.ChartData.Categories.Add(wb.GetCell(0, "C4", "Leaf 4"));

                                // Branch 2
                                leaf = treemapChart.ChartData.Categories.Add(wb.GetCell(0, "C5", "Leaf 5"));
                                leaf.GroupingLevels.SetGroupingItem(0, "Stem 3");
                                leaf.GroupingLevels.SetGroupingItem(1, "Branch 2");
                                treemapChart.ChartData.Categories.Add(wb.GetCell(0, "C6", "Leaf 6"));
                                leaf = treemapChart.ChartData.Categories.Add(wb.GetCell(0, "C7", "Leaf 7"));
                                leaf.GroupingLevels.SetGroupingItem(0, "Stem 4");
                                treemapChart.ChartData.Categories.Add(wb.GetCell(0, "C8", "Leaf 8"));

                                // Series data
                                IChartSeries series = treemapChart.ChartData.Series.Add(ChartType.Treemap);
                                series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
                                series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D1", 10));
                                series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D2", 20));
                                series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D3", 30));
                                series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D4", 40));
                                series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D5", 50));
                                series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D6", 60));
                                series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D7", 70));
                                series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D8", 80));
                                series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;
                            }
                        }
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception)
            {
                // Format not supported or other error handling
            }
        }
    }
}
