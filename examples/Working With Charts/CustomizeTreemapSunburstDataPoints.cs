using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // ==================== Treemap Chart ====================
        Aspose.Slides.ISlide treemapSlide = pres.Slides[0];
        Aspose.Slides.Charts.IChart treemapChart = treemapSlide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Treemap, 50, 50, 500, 400);
        treemapChart.ChartData.Categories.Clear();
        treemapChart.ChartData.Series.Clear();
        Aspose.Slides.Charts.IChartDataWorkbook treemapWb = treemapChart.ChartData.ChartDataWorkbook;
        treemapWb.Clear(0);

        // Add categories with grouping levels
        Aspose.Slides.Charts.IChartCategory leaf = treemapChart.ChartData.Categories.Add(treemapWb.GetCell(0, "C1", "Leaf1"));
        leaf.GroupingLevels.SetGroupingItem(0, "Stem1");
        leaf.GroupingLevels.SetGroupingItem(1, "Branch1");
        treemapChart.ChartData.Categories.Add(treemapWb.GetCell(0, "C2", "Leaf2"));
        leaf = treemapChart.ChartData.Categories.Add(treemapWb.GetCell(0, "C3", "Leaf3"));
        leaf.GroupingLevels.SetGroupingItem(0, "Stem2");
        treemapChart.ChartData.Categories.Add(treemapWb.GetCell(0, "C4", "Leaf4"));

        // Add series and data points
        Aspose.Slides.Charts.IChartSeries treemapSeries = treemapChart.ChartData.Series.Add(Aspose.Slides.Charts.ChartType.Treemap);
        treemapSeries.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
        treemapSeries.DataPoints.AddDataPointForTreemapSeries(treemapWb.GetCell(0, "D1", 10));
        treemapSeries.DataPoints.AddDataPointForTreemapSeries(treemapWb.GetCell(0, "D2", 20));
        treemapSeries.DataPoints.AddDataPointForTreemapSeries(treemapWb.GetCell(0, "D3", 30));
        treemapSeries.DataPoints.AddDataPointForTreemapSeries(treemapWb.GetCell(0, "D4", 40));
        treemapSeries.ParentLabelLayout = Aspose.Slides.Charts.ParentLabelLayoutType.Overlapping;

        // Customize first data point level
        Aspose.Slides.Charts.IChartDataPoint treemapDataPoint = treemapSeries.DataPoints[0];
        Aspose.Slides.Charts.IChartDataPointLevel treemapLevel = treemapDataPoint.DataPointLevels[0];
        treemapLevel.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        treemapLevel.Format.Fill.SolidFillColor.Color = Color.LightBlue;
        treemapLevel.Label.DataLabelFormat.ShowValue = true;

        // ==================== Sunburst Chart ====================
        Aspose.Slides.ISlide sunburstSlide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
        Aspose.Slides.Charts.IChart sunburstChart = sunburstSlide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Sunburst, 50, 500, 500, 400);
        sunburstChart.ChartData.Categories.Clear();
        sunburstChart.ChartData.Series.Clear();
        Aspose.Slides.Charts.IChartDataWorkbook sunburstWb = sunburstChart.ChartData.ChartDataWorkbook;
        sunburstWb.Clear(0);

        // Add categories with grouping levels
        Aspose.Slides.Charts.IChartCategory sunLeaf = sunburstChart.ChartData.Categories.Add(sunburstWb.GetCell(0, "C1", "LeafA"));
        sunLeaf.GroupingLevels.SetGroupingItem(0, "StemA");
        sunLeaf.GroupingLevels.SetGroupingItem(1, "BranchA");
        sunburstChart.ChartData.Categories.Add(sunburstWb.GetCell(0, "C2", "LeafB"));
        sunLeaf = sunburstChart.ChartData.Categories.Add(sunburstWb.GetCell(0, "C3", "LeafC"));
        sunLeaf.GroupingLevels.SetGroupingItem(0, "StemB");
        sunburstChart.ChartData.Categories.Add(sunburstWb.GetCell(0, "C4", "LeafD"));

        // Add series and data points
        Aspose.Slides.Charts.IChartSeries sunburstSeries = sunburstChart.ChartData.Series.Add(Aspose.Slides.Charts.ChartType.Sunburst);
        sunburstSeries.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
        sunburstSeries.DataPoints.AddDataPointForSunburstSeries(sunburstWb.GetCell(0, "D1", 15));
        sunburstSeries.DataPoints.AddDataPointForSunburstSeries(sunburstWb.GetCell(0, "D2", 25));
        sunburstSeries.DataPoints.AddDataPointForSunburstSeries(sunburstWb.GetCell(0, "D3", 35));
        sunburstSeries.DataPoints.AddDataPointForSunburstSeries(sunburstWb.GetCell(0, "D4", 45));

        // Customize second data point level
        Aspose.Slides.Charts.IChartDataPoint sunDataPoint = sunburstSeries.DataPoints[1];
        Aspose.Slides.Charts.IChartDataPointLevel sunLevel = sunDataPoint.DataPointLevels[1];
        sunLevel.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        sunLevel.Format.Fill.SolidFillColor.Color = Color.Orange;
        sunLevel.Label.DataLabelFormat.ShowValue = true;

        // Save the presentation
        pres.Save("TreemapSunburstCustomization.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}