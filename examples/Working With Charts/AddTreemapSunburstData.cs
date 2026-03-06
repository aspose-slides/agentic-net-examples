using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AddTreemapSunburstData
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // ---------- Treemap Chart ----------
            Aspose.Slides.ISlide slide = pres.Slides[0];
            Aspose.Slides.Charts.IChart treemapChart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Treemap, 50f, 50f, 500f, 400f);
            treemapChart.ChartData.Categories.Clear();
            treemapChart.ChartData.Series.Clear();
            Aspose.Slides.Charts.IChartDataWorkbook wb = treemapChart.ChartData.ChartDataWorkbook;
            wb.Clear(0);

            // Add categories with grouping levels
            Aspose.Slides.Charts.IChartCategory leaf = treemapChart.ChartData.Categories.Add(wb.GetCell(0, "C1", "Stem1"));
            leaf.GroupingLevels.SetGroupingItem(0, "Stem1");
            leaf.GroupingLevels.SetGroupingItem(1, "Branch1");

            treemapChart.ChartData.Categories.Add(wb.GetCell(0, "C2", "Leaf2"));
            leaf = treemapChart.ChartData.Categories.Add(wb.GetCell(0, "C3", "Leaf3"));
            leaf.GroupingLevels.SetGroupingItem(0, "Stem2");
            leaf.GroupingLevels.SetGroupingItem(1, "Branch2");
            treemapChart.ChartData.Categories.Add(wb.GetCell(0, "C4", "Leaf4"));

            // Add more categories for demonstration
            leaf = treemapChart.ChartData.Categories.Add(wb.GetCell(0, "C5", "Stem3"));
            leaf.GroupingLevels.SetGroupingItem(0, "Stem3");
            leaf.GroupingLevels.SetGroupingItem(1, "Branch3");
            treemapChart.ChartData.Categories.Add(wb.GetCell(0, "C6", "Leaf5"));
            leaf = treemapChart.ChartData.Categories.Add(wb.GetCell(0, "C7", "Stem4"));
            leaf.GroupingLevels.SetGroupingItem(0, "Stem4");
            treemapChart.ChartData.Categories.Add(wb.GetCell(0, "C8", "Leaf6"));

            // Add series and data points
            Aspose.Slides.Charts.IChartSeries treemapSeries = treemapChart.ChartData.Series.Add(Aspose.Slides.Charts.ChartType.Treemap);
            treemapSeries.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
            treemapSeries.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D1", 10));
            treemapSeries.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D2", 20));
            treemapSeries.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D3", 30));
            treemapSeries.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D4", 40));
            treemapSeries.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D5", 50));
            treemapSeries.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D6", 60));
            treemapSeries.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D7", 70));
            treemapSeries.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D8", 80));
            treemapSeries.ParentLabelLayout = Aspose.Slides.Charts.ParentLabelLayoutType.Overlapping;

            // ---------- Sunburst Chart ----------
            Aspose.Slides.ISlide slide2 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
            Aspose.Slides.Charts.IChart sunburstChart = slide2.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Sunburst, 50f, 50f, 500f, 400f);
            sunburstChart.ChartData.Categories.Clear();
            sunburstChart.ChartData.Series.Clear();
            Aspose.Slides.Charts.IChartDataWorkbook wb2 = sunburstChart.ChartData.ChartDataWorkbook;
            wb2.Clear(0);

            // Add categories with grouping levels for sunburst
            Aspose.Slides.Charts.IChartCategory leaf2 = sunburstChart.ChartData.Categories.Add(wb2.GetCell(0, "C1", "StemA"));
            leaf2.GroupingLevels.SetGroupingItem(0, "StemA");
            leaf2.GroupingLevels.SetGroupingItem(1, "BranchA");

            sunburstChart.ChartData.Categories.Add(wb2.GetCell(0, "C2", "LeafB"));
            leaf2 = sunburstChart.ChartData.Categories.Add(wb2.GetCell(0, "C3", "LeafC"));
            leaf2.GroupingLevels.SetGroupingItem(0, "StemB");
            sunburstChart.ChartData.Categories.Add(wb2.GetCell(0, "C4", "LeafD"));
            leaf2 = sunburstChart.ChartData.Categories.Add(wb2.GetCell(0, "C5", "StemC"));
            leaf2.GroupingLevels.SetGroupingItem(0, "StemC");
            leaf2.GroupingLevels.SetGroupingItem(1, "BranchC");
            sunburstChart.ChartData.Categories.Add(wb2.GetCell(0, "C6", "LeafE"));
            leaf2 = sunburstChart.ChartData.Categories.Add(wb2.GetCell(0, "C7", "StemD"));
            leaf2.GroupingLevels.SetGroupingItem(0, "StemD");
            sunburstChart.ChartData.Categories.Add(wb2.GetCell(0, "C8", "LeafF"));

            // Add series and data points for sunburst
            Aspose.Slides.Charts.IChartSeries sunburstSeries = sunburstChart.ChartData.Series.Add(Aspose.Slides.Charts.ChartType.Sunburst);
            sunburstSeries.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
            sunburstSeries.DataPoints.AddDataPointForSunburstSeries(wb2.GetCell(0, "D1", 15));
            sunburstSeries.DataPoints.AddDataPointForSunburstSeries(wb2.GetCell(0, "D2", 25));
            sunburstSeries.DataPoints.AddDataPointForSunburstSeries(wb2.GetCell(0, "D3", 35));
            sunburstSeries.DataPoints.AddDataPointForSunburstSeries(wb2.GetCell(0, "D4", 45));
            sunburstSeries.DataPoints.AddDataPointForSunburstSeries(wb2.GetCell(0, "D5", 55));
            sunburstSeries.DataPoints.AddDataPointForSunburstSeries(wb2.GetCell(0, "D6", 65));
            sunburstSeries.DataPoints.AddDataPointForSunburstSeries(wb2.GetCell(0, "D7", 75));
            sunburstSeries.DataPoints.AddDataPointForSunburstSeries(wb2.GetCell(0, "D8", 85));

            // Save the presentation
            pres.Save("TreemapSunburstChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}