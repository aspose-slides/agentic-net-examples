using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace TreemapChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a Treemap chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.Treemap, 50f, 50f, 500f, 400f);

            // Clear default categories and series
            chart.ChartData.Categories.Clear();
            chart.ChartData.Series.Clear();

            // Get the chart data workbook
            IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;
            wb.Clear(0);

            // Branch 1
            IChartCategory leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C1", "Leaf1"));
            leaf.GroupingLevels.SetGroupingItem(0, "Stem1");
            leaf.GroupingLevels.SetGroupingItem(1, "Branch1");
            chart.ChartData.Categories.Add(wb.GetCell(0, "C2", "Leaf2"));
            leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C3", "Leaf3"));
            leaf.GroupingLevels.SetGroupingItem(0, "Stem2");
            chart.ChartData.Categories.Add(wb.GetCell(0, "C4", "Leaf4"));

            // Branch 2
            leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C5", "Leaf5"));
            leaf.GroupingLevels.SetGroupingItem(0, "Stem3");
            leaf.GroupingLevels.SetGroupingItem(1, "Branch2");
            chart.ChartData.Categories.Add(wb.GetCell(0, "C6", "Leaf6"));
            leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C7", "Leaf7"));
            leaf.GroupingLevels.SetGroupingItem(0, "Stem4");
            chart.ChartData.Categories.Add(wb.GetCell(0, "C8", "Leaf8"));

            // Add a series for the Treemap chart
            IChartSeries series = chart.ChartData.Series.Add(ChartType.Treemap);
            series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

            // Add data points (size values) for each leaf
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

            // Save the presentation
            pres.Save("TreemapChart_out.pptx", SaveFormat.Pptx);
        }
    }
}