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
        var pres = new Aspose.Slides.Presentation();

        // ------------------- Treemap Chart -------------------
        var slide = pres.Slides[0];
        var treemapChart = slide.Shapes.AddChart(ChartType.Treemap, 50, 50, 500, 400);
        treemapChart.ChartData.Categories.Clear();
        treemapChart.ChartData.Series.Clear();
        var wb = treemapChart.ChartData.ChartDataWorkbook;
        wb.Clear(0);

        // Add categories (leaves) with grouping levels
        var leaf = treemapChart.ChartData.Categories.Add(wb.GetCell(0, "C1", "Leaf 1"));
        leaf.GroupingLevels.SetGroupingItem(0, "Stem A");
        leaf.GroupingLevels.SetGroupingItem(1, "Branch X");
        treemapChart.ChartData.Categories.Add(wb.GetCell(0, "C2", "Leaf 2"));
        leaf = treemapChart.ChartData.Categories.Add(wb.GetCell(0, "C3", "Leaf 3"));
        leaf.GroupingLevels.SetGroupingItem(0, "Stem B");
        leaf.GroupingLevels.SetGroupingItem(1, "Branch Y");
        treemapChart.ChartData.Categories.Add(wb.GetCell(0, "C4", "Leaf 4"));

        // Add series and data points
        var treemapSeries = treemapChart.ChartData.Series.Add(ChartType.Treemap);
        treemapSeries.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
        treemapSeries.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D1", 10));
        treemapSeries.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D2", 20));
        treemapSeries.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D3", 30));
        treemapSeries.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D4", 40));
        treemapSeries.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

        // Customize individual data point (third point) - set fill color
        var treemapDataPoint3 = treemapSeries.DataPoints[2];
        treemapDataPoint3.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        treemapDataPoint3.Format.Fill.SolidFillColor.Color = Color.Orange;

        // ------------------- Sunburst Chart -------------------
        var sunburstChart = slide.Shapes.AddChart(ChartType.Sunburst, 50, 500, 500, 400);
        sunburstChart.ChartData.Categories.Clear();
        sunburstChart.ChartData.Series.Clear();
        var wb2 = sunburstChart.ChartData.ChartDataWorkbook;
        wb2.Clear(0);

        // Add categories (leaves) with grouping levels
        var leaf2 = sunburstChart.ChartData.Categories.Add(wb2.GetCell(0, "C1", "Leaf A"));
        leaf2.GroupingLevels.SetGroupingItem(0, "Stem A");
        leaf2.GroupingLevels.SetGroupingItem(1, "Branch A");
        sunburstChart.ChartData.Categories.Add(wb2.GetCell(0, "C2", "Leaf B"));
        leaf2 = sunburstChart.ChartData.Categories.Add(wb2.GetCell(0, "C3", "Leaf C"));
        leaf2.GroupingLevels.SetGroupingItem(0, "Stem B");
        sunburstChart.ChartData.Categories.Add(wb2.GetCell(0, "C4", "Leaf D"));
        leaf2 = sunburstChart.ChartData.Categories.Add(wb2.GetCell(0, "C5", "Leaf E"));
        leaf2.GroupingLevels.SetGroupingItem(0, "Stem C");
        leaf2.GroupingLevels.SetGroupingItem(1, "Branch B");
        sunburstChart.ChartData.Categories.Add(wb2.GetCell(0, "C6", "Leaf F"));
        leaf2 = sunburstChart.ChartData.Categories.Add(wb2.GetCell(0, "C7", "Leaf G"));
        leaf2.GroupingLevels.SetGroupingItem(0, "Stem D");
        sunburstChart.ChartData.Categories.Add(wb2.GetCell(0, "C8", "Leaf H"));

        // Add series and data points
        var sunburstSeries = sunburstChart.ChartData.Series.Add(ChartType.Sunburst);
        sunburstSeries.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
        sunburstSeries.DataPoints.AddDataPointForSunburstSeries(wb2.GetCell(0, "D1", 15));
        sunburstSeries.DataPoints.AddDataPointForSunburstSeries(wb2.GetCell(0, "D2", 25));
        sunburstSeries.DataPoints.AddDataPointForSunburstSeries(wb2.GetCell(0, "D3", 35));
        sunburstSeries.DataPoints.AddDataPointForSunburstSeries(wb2.GetCell(0, "D4", 45));
        sunburstSeries.DataPoints.AddDataPointForSunburstSeries(wb2.GetCell(0, "D5", 55));
        sunburstSeries.DataPoints.AddDataPointForSunburstSeries(wb2.GetCell(0, "D6", 65));
        sunburstSeries.DataPoints.AddDataPointForSunburstSeries(wb2.GetCell(0, "D7", 75));
        sunburstSeries.DataPoints.AddDataPointForSunburstSeries(wb2.GetCell(0, "D8", 85));

        // Customize individual data point (second point) - show value in label
        var sunburstDataPoint2 = sunburstSeries.DataPoints[1];
        sunburstDataPoint2.Label.DataLabelFormat.ShowValue = true;

        // Customize individual data point (first point) - set fill color
        var sunburstDataPoint1 = sunburstSeries.DataPoints[0];
        sunburstDataPoint1.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        sunburstDataPoint1.Format.Fill.SolidFillColor.Color = Color.LightBlue;

        // Save the presentation
        pres.Save("CustomizedCharts.pptx", SaveFormat.Pptx);
    }
}