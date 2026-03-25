using System;
using System.IO;
using Aspose.Slides.Export;
using System.Drawing;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Optional input file handling
            if (args.Length > 0)
            {
                var inputPath = args[0];
                if (!File.Exists(inputPath))
                {
                    Console.WriteLine("Input file not found: " + inputPath);
                    return;
                }
                // Load existing presentation if needed (not used in this example)
                // var pres = new Aspose.Slides.Presentation(inputPath);
            }

            var outputPath = "CustomTreemapSunburst.pptx";

            // Create a new presentation
            var pres = new Aspose.Slides.Presentation();

            // Add a treemap chart
            var slide = pres.Slides[0];
            var treemapChart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Treemap, 50, 50, 500, 400);
            treemapChart.ChartData.Categories.Clear();
            treemapChart.ChartData.Series.Clear();
            var wb = treemapChart.ChartData.ChartDataWorkbook;
            wb.Clear(0);

            // Define categories (leaves) with grouping
            var leaf = treemapChart.ChartData.Categories.Add(wb.GetCell(0, "C1", "Leaf1"));
            leaf.GroupingLevels.SetGroupingItem(0, "Stem1");
            leaf.GroupingLevels.SetGroupingItem(1, "Branch1");
            treemapChart.ChartData.Categories.Add(wb.GetCell(0, "C2", "Leaf2"));
            leaf = treemapChart.ChartData.Categories.Add(wb.GetCell(0, "C3", "Leaf3"));
            leaf.GroupingLevels.SetGroupingItem(0, "Stem2");
            treemapChart.ChartData.Categories.Add(wb.GetCell(0, "C4", "Leaf4"));

            // Add series and data points
            var series = treemapChart.ChartData.Series.Add(Aspose.Slides.Charts.ChartType.Treemap);
            series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
            series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D1", 10));
            series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D2", 20));
            series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D3", 30));
            series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D4", 40));
            series.ParentLabelLayout = Aspose.Slides.Charts.ParentLabelLayoutType.Overlapping;

            // Custom formatting for a treemap data point level
            var treemapLevel = series.DataPoints[0].DataPointLevels[0];
            treemapLevel.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
            treemapLevel.Format.Fill.SolidFillColor.Color = Color.Blue;
            treemapLevel.Label.DataLabelFormat.ShowValue = true;

            // Add a sunburst chart
            var sunburstChart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Sunburst, 50, 460, 500, 400);
            sunburstChart.ChartData.Categories.Clear();
            sunburstChart.ChartData.Series.Clear();
            var wb2 = sunburstChart.ChartData.ChartDataWorkbook;
            wb2.Clear(0);

            // Define categories (leaves) with grouping
            var leaf2 = sunburstChart.ChartData.Categories.Add(wb2.GetCell(0, "C1", "Root"));
            leaf2.GroupingLevels.SetGroupingItem(0, "RootStem");
            sunburstChart.ChartData.Categories.Add(wb2.GetCell(0, "C2", "Child1"));
            leaf2 = sunburstChart.ChartData.Categories.Add(wb2.GetCell(0, "C3", "Child2"));
            leaf2.GroupingLevels.SetGroupingItem(0, "ChildStem");
            leaf2.GroupingLevels.SetGroupingItem(1, "ChildBranch");
            sunburstChart.ChartData.Categories.Add(wb2.GetCell(0, "C4", "Child3"));

            // Add series and data points
            var series2 = sunburstChart.ChartData.Series.Add(Aspose.Slides.Charts.ChartType.Sunburst);
            series2.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
            series2.DataPoints.AddDataPointForSunburstSeries(wb2.GetCell(0, "D1", 15));
            series2.DataPoints.AddDataPointForSunburstSeries(wb2.GetCell(0, "D2", 25));
            series2.DataPoints.AddDataPointForSunburstSeries(wb2.GetCell(0, "D3", 35));
            series2.DataPoints.AddDataPointForSunburstSeries(wb2.GetCell(0, "D4", 45));

            // Custom formatting for a sunburst data point level
            var sunburstLevel = series2.DataPoints[1].DataPointLevels[1];
            sunburstLevel.Label.DataLabelFormat.ShowCategoryName = false;
            sunburstLevel.Label.DataLabelFormat.ShowValue = true;
            sunburstLevel.Label.TextFormat.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            sunburstLevel.Label.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Green;

            // Save the presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}