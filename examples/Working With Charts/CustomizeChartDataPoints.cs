using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // -------------------- Treemap Chart --------------------
        Aspose.Slides.ISlide slide1 = pres.Slides[0];
        Aspose.Slides.Charts.IChart treemapChart = slide1.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Treemap, 50, 50, 500, 400);
        treemapChart.ChartData.Categories.Clear();
        treemapChart.ChartData.Series.Clear();
        Aspose.Slides.Charts.IChartDataWorkbook wb1 = treemapChart.ChartData.ChartDataWorkbook;
        wb1.Clear(0);

        // Add categories (root, branch, leaf)
        Aspose.Slides.Charts.IChartCategory leaf;
        leaf = treemapChart.ChartData.Categories.Add(wb1.GetCell(0, "C1", "Root"));
        leaf.GroupingLevels.SetGroupingItem(0, "Root");
        leaf = treemapChart.ChartData.Categories.Add(wb1.GetCell(0, "C2", "Branch1"));
        leaf.GroupingLevels.SetGroupingItem(0, "Root");
        leaf.GroupingLevels.SetGroupingItem(1, "Branch1");
        leaf = treemapChart.ChartData.Categories.Add(wb1.GetCell(0, "C3", "Leaf1"));
        leaf.GroupingLevels.SetGroupingItem(0, "Root");
        leaf.GroupingLevels.SetGroupingItem(1, "Branch1");

        // Add series and data points
        Aspose.Slides.Charts.IChartSeries treemapSeries = treemapChart.ChartData.Series.Add(Aspose.Slides.Charts.ChartType.Treemap);
        treemapSeries.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
        treemapSeries.DataPoints.AddDataPointForTreemapSeries(wb1.GetCell(0, "D1", 30));
        treemapSeries.DataPoints.AddDataPointForTreemapSeries(wb1.GetCell(0, "D2", 70));

        // Customize first data point level (fill color)
        Aspose.Slides.Charts.IChartDataPoint treemapPoint0 = treemapSeries.DataPoints[0];
        Aspose.Slides.Charts.IChartDataPointLevel treemapLevel0 = treemapPoint0.DataPointLevels[0];
        treemapLevel0.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        treemapLevel0.Format.Fill.SolidFillColor.Color = System.Drawing.Color.LightBlue;

        // -------------------- Sunburst Chart --------------------
        Aspose.Slides.ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
        Aspose.Slides.Charts.IChart sunburstChart = slide2.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Sunburst, 50, 50, 500, 400);
        sunburstChart.ChartData.Categories.Clear();
        sunburstChart.ChartData.Series.Clear();
        Aspose.Slides.Charts.IChartDataWorkbook wb2 = sunburstChart.ChartData.ChartDataWorkbook;
        wb2.Clear(0);

        // Add categories (world, continent, country)
        leaf = sunburstChart.ChartData.Categories.Add(wb2.GetCell(0, "C1", "World"));
        leaf.GroupingLevels.SetGroupingItem(0, "World");
        leaf = sunburstChart.ChartData.Categories.Add(wb2.GetCell(0, "C2", "Europe"));
        leaf.GroupingLevels.SetGroupingItem(0, "World");
        leaf.GroupingLevels.SetGroupingItem(1, "Europe");
        leaf = sunburstChart.ChartData.Categories.Add(wb2.GetCell(0, "C3", "Germany"));
        leaf.GroupingLevels.SetGroupingItem(0, "World");
        leaf.GroupingLevels.SetGroupingItem(1, "Europe");
        leaf.GroupingLevels.SetGroupingItem(2, "Germany");

        // Add series and data points
        Aspose.Slides.Charts.IChartSeries sunburstSeries = sunburstChart.ChartData.Series.Add(Aspose.Slides.Charts.ChartType.Sunburst);
        sunburstSeries.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
        sunburstSeries.DataPoints.AddDataPointForSunburstSeries(wb2.GetCell(0, "D1", 50));
        sunburstSeries.DataPoints.AddDataPointForSunburstSeries(wb2.GetCell(0, "D2", 30));

        // Customize second level label (show value and set text color)
        Aspose.Slides.Charts.IChartDataPoint sunburstPoint1 = sunburstSeries.DataPoints[1];
        Aspose.Slides.Charts.IChartDataPointLevel sunburstLevel1 = sunburstPoint1.DataPointLevels[1];
        sunburstLevel1.Label.DataLabelFormat.ShowValue = true;
        sunburstLevel1.Label.TextFormat.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        sunburstLevel1.Label.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.OrangeRed;

        // Save the presentation
        pres.Save("CustomizedTreemapSunburst.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}