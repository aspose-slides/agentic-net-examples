using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = "CustomizedCharts.pptx";

            try
            {
                // Create a new presentation
                using (Presentation pres = new Presentation())
                {
                    // ------------------- Treemap Chart -------------------
                    ISlide treemapSlide = pres.Slides[0];
                    IChart treemapChart = treemapSlide.Shapes.AddChart(ChartType.Treemap, 50f, 50f, 500f, 400f);

                    // Clear default categories and series
                    treemapChart.ChartData.Categories.Clear();
                    treemapChart.ChartData.Series.Clear();

                    IChartDataWorkbook treemapWb = treemapChart.ChartData.ChartDataWorkbook;
                    treemapWb.Clear(0);

                    // Add a leaf category with grouping levels
                    IChartCategory treemapLeaf = treemapChart.ChartData.Categories.Add(treemapWb.GetCell(0, "C1", "Leaf1"));
                    treemapLeaf.GroupingLevels.SetGroupingItem(0, "Stem1");
                    treemapLeaf.GroupingLevels.SetGroupingItem(1, "Branch1");

                    // Add series
                    IChartSeries treemapSeries = treemapChart.ChartData.Series.Add(ChartType.Treemap);
                    treemapSeries.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
                    treemapSeries.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

                    // Add data points
                    IChartDataPoint treemapDp1 = treemapSeries.DataPoints.AddDataPointForTreemapSeries(treemapWb.GetCell(0, "D1", 10));
                    IChartDataPoint treemapDp2 = treemapSeries.DataPoints.AddDataPointForTreemapSeries(treemapWb.GetCell(0, "D2", 20));

                    // Customize first data point level label (show value and set fill color)
                    IChartDataPointLevel treemapLevel0 = treemapDp1.DataPointLevels[0];
                    treemapLevel0.Label.DataLabelFormat.ShowValue = true;
                    treemapLevel0.Label.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
                    treemapLevel0.Label.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;

                    // ------------------- Sunburst Chart -------------------
                    ISlide sunburstSlide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
                    IChart sunburstChart = sunburstSlide.Shapes.AddChart(ChartType.Sunburst, 50f, 50f, 500f, 400f);

                    // Clear default categories and series
                    sunburstChart.ChartData.Categories.Clear();
                    sunburstChart.ChartData.Series.Clear();

                    IChartDataWorkbook sunburstWb = sunburstChart.ChartData.ChartDataWorkbook;
                    sunburstWb.Clear(0);

                    // Add a leaf category with grouping levels
                    IChartCategory sunburstLeaf = sunburstChart.ChartData.Categories.Add(sunburstWb.GetCell(0, "C1", "LeafA"));
                    sunburstLeaf.GroupingLevels.SetGroupingItem(0, "StemA");
                    sunburstLeaf.GroupingLevels.SetGroupingItem(1, "BranchA");

                    // Add series
                    IChartSeries sunburstSeries = sunburstChart.ChartData.Series.Add(ChartType.Sunburst);
                    sunburstSeries.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

                    // Add data point
                    IChartDataPoint sunburstDp1 = sunburstSeries.DataPoints.AddDataPointForSunburstSeries(sunburstWb.GetCell(0, "D1", 15));

                    // Customize second level label (hide category name, show value, set fill color)
                    IChartDataPointLevel sunburstLevel1 = sunburstDp1.DataPointLevels[1];
                    sunburstLevel1.Label.DataLabelFormat.ShowCategoryName = false;
                    sunburstLevel1.Label.DataLabelFormat.ShowValue = true;
                    sunburstLevel1.Label.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
                    sunburstLevel1.Label.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

                    // Save the presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (FileNotFoundException fnfEx)
            {
                Console.WriteLine("Input file not found: " + fnfEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}