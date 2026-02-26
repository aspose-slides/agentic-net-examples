using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // -------------------- Treemap Chart --------------------
            // Add a treemap chart
            Aspose.Slides.Charts.IChart treemapChart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Treemap, 0, 0, 500, 400);

            // Clear default categories and series
            treemapChart.ChartData.Categories.Clear();
            treemapChart.ChartData.Series.Clear();

            // Get the chart data workbook and clear it
            Aspose.Slides.Charts.IChartDataWorkbook treemapWb = treemapChart.ChartData.ChartDataWorkbook;
            treemapWb.Clear(0);

            // Add categories (leaves) with grouping
            Aspose.Slides.Charts.IChartCategory leaf1 = treemapChart.ChartData.Categories.Add(
                treemapWb.GetCell(0, "B2", "Leaf1"));
            leaf1.GroupingLevels.SetGroupingItem(0, "Stem1");
            leaf1.GroupingLevels.SetGroupingItem(1, "Branch1");

            Aspose.Slides.Charts.IChartCategory leaf2 = treemapChart.ChartData.Categories.Add(
                treemapWb.GetCell(0, "B3", "Leaf2"));
            leaf2.GroupingLevels.SetGroupingItem(0, "Stem2");
            leaf2.GroupingLevels.SetGroupingItem(1, "Branch2");

            // Add a series for the treemap
            Aspose.Slides.Charts.IChartSeries treemapSeries = treemapChart.ChartData.Series.Add(
                Aspose.Slides.Charts.ChartType.Treemap);
            treemapSeries.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

            // Add data points (size values) for the series
            treemapSeries.DataPoints.AddDataPointForTreemapSeries(
                treemapWb.GetCell(0, "C2", 30));
            treemapSeries.DataPoints.AddDataPointForTreemapSeries(
                treemapWb.GetCell(0, "C3", 70));

            // Set parent label layout
            treemapSeries.ParentLabelLayout = Aspose.Slides.Charts.ParentLabelLayoutType.Overlapping;

            // -------------------- Sunburst Chart --------------------
            // Add a sunburst chart
            Aspose.Slides.Charts.IChart sunburstChart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Sunburst, 0, 450, 500, 400);

            // Clear default categories and series
            sunburstChart.ChartData.Categories.Clear();
            sunburstChart.ChartData.Series.Clear();

            // Get the chart data workbook and clear it
            Aspose.Slides.Charts.IChartDataWorkbook sunburstWb = sunburstChart.ChartData.ChartDataWorkbook;
            sunburstWb.Clear(0);

            // Add categories (leaves) with grouping
            Aspose.Slides.Charts.IChartCategory sLeaf1 = sunburstChart.ChartData.Categories.Add(
                sunburstWb.GetCell(0, "B2", "SLeaf1"));
            sLeaf1.GroupingLevels.SetGroupingItem(0, "SStem1");
            sLeaf1.GroupingLevels.SetGroupingItem(1, "SBranch1");

            Aspose.Slides.Charts.IChartCategory sLeaf2 = sunburstChart.ChartData.Categories.Add(
                sunburstWb.GetCell(0, "B3", "SLeaf2"));
            sLeaf2.GroupingLevels.SetGroupingItem(0, "SStem2");
            sLeaf2.GroupingLevels.SetGroupingItem(1, "SBranch2");

            // Add a series for the sunburst
            Aspose.Slides.Charts.IChartSeries sunburstSeries = sunburstChart.ChartData.Series.Add(
                Aspose.Slides.Charts.ChartType.Sunburst);
            sunburstSeries.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

            // Add data points (size values) for the series
            sunburstSeries.DataPoints.AddDataPointForSunburstSeries(
                sunburstWb.GetCell(0, "C2", 40));
            sunburstSeries.DataPoints.AddDataPointForSunburstSeries(
                sunburstWb.GetCell(0, "C3", 60));

            // Save the presentation
            pres.Save("TreemapSunburstChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}