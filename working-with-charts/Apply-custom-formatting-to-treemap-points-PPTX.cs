using System;
using System.IO;
using System.Drawing;
using Aspose.Slides.Export;

namespace CustomDataPointFormatting
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output file path
            string outputFile = "CustomDataPoints.pptx";

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // ==========================
            // Treemap chart with custom formatting
            // ==========================
            Aspose.Slides.ISlide treemapSlide = presentation.Slides[0];
            Aspose.Slides.Charts.IChart treemapChart = treemapSlide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Treemap, 50, 50, 500, 400);
            treemapChart.ChartData.Categories.Clear();
            treemapChart.ChartData.Series.Clear();

            Aspose.Slides.Charts.IChartDataWorkbook treemapWb = treemapChart.ChartData.ChartDataWorkbook;
            treemapWb.Clear(0);

            // Add categories (leaves) with grouping
            Aspose.Slides.Charts.IChartCategory leaf1 = treemapChart.ChartData.Categories.Add(
                treemapWb.GetCell(0, "C1", "Leaf 1"));
            leaf1.GroupingLevels.SetGroupingItem(0, "Stem A");
            leaf1.GroupingLevels.SetGroupingItem(1, "Branch X");

            Aspose.Slides.Charts.IChartCategory leaf2 = treemapChart.ChartData.Categories.Add(
                treemapWb.GetCell(0, "C2", "Leaf 2"));
            leaf2.GroupingLevels.SetGroupingItem(0, "Stem A");
            leaf2.GroupingLevels.SetGroupingItem(1, "Branch Y");

            // Add series
            Aspose.Slides.Charts.IChartSeries treemapSeries = treemapChart.ChartData.Series.Add(
                Aspose.Slides.Charts.ChartType.Treemap);
            treemapSeries.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

            // Add data points (size values)
            treemapSeries.DataPoints.AddDataPointForTreemapSeries(
                treemapWb.GetCell(0, "D1", 30));
            treemapSeries.DataPoints.AddDataPointForTreemapSeries(
                treemapWb.GetCell(0, "D2", 20));
            treemapSeries.DataPoints.AddDataPointForTreemapSeries(
                treemapWb.GetCell(0, "D3", 50));

            // Custom formatting for first data point level
            Aspose.Slides.Charts.IChartDataPoint treemapDataPoint = treemapSeries.DataPoints[0];
            Aspose.Slides.Charts.IChartDataPointLevel treemapLevel = treemapDataPoint.DataPointLevels[0];
            treemapLevel.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
            treemapLevel.Format.Fill.SolidFillColor.Color = Color.Red;
            treemapLevel.Label.DataLabelFormat.ShowValue = true;

            // ==========================
            // Sunburst chart with custom formatting
            // ==========================
            Aspose.Slides.ISlide sunburstSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            Aspose.Slides.Charts.IChart sunburstChart = sunburstSlide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Sunburst, 50, 50, 500, 400);
            sunburstChart.ChartData.Categories.Clear();
            sunburstChart.ChartData.Series.Clear();

            Aspose.Slides.Charts.IChartDataWorkbook sunburstWb = sunburstChart.ChartData.ChartDataWorkbook;
            sunburstWb.Clear(0);

            // Add categories (leaves) with grouping
            Aspose.Slides.Charts.IChartCategory sLeaf1 = sunburstChart.ChartData.Categories.Add(
                sunburstWb.GetCell(0, "C1", "Leaf A"));
            sLeaf1.GroupingLevels.SetGroupingItem(0, "Stem 1");
            sLeaf1.GroupingLevels.SetGroupingItem(1, "Branch Alpha");

            Aspose.Slides.Charts.IChartCategory sLeaf2 = sunburstChart.ChartData.Categories.Add(
                sunburstWb.GetCell(0, "C2", "Leaf B"));
            sLeaf2.GroupingLevels.SetGroupingItem(0, "Stem 1");
            sLeaf2.GroupingLevels.SetGroupingItem(1, "Branch Beta");

            // Add series
            Aspose.Slides.Charts.IChartSeries sunburstSeries = sunburstChart.ChartData.Series.Add(
                Aspose.Slides.Charts.ChartType.Sunburst);
            sunburstSeries.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

            // Add data points (size values)
            sunburstSeries.DataPoints.AddDataPointForSunburstSeries(
                sunburstWb.GetCell(0, "D1", 40));
            sunburstSeries.DataPoints.AddDataPointForSunburstSeries(
                sunburstWb.GetCell(0, "D2", 60));

            // Custom formatting for second data point level of first data point
            Aspose.Slides.Charts.IChartDataPoint sunburstDataPoint = sunburstSeries.DataPoints[0];
            Aspose.Slides.Charts.IChartDataPointLevel sunburstLevel = sunburstDataPoint.DataPointLevels[1];
            sunburstLevel.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
            sunburstLevel.Format.Fill.SolidFillColor.Color = Color.Blue;
            sunburstLevel.Label.DataLabelFormat.ShowSeriesName = true;

            // Save the presentation
            presentation.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}