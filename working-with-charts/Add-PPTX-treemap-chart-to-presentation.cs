using System;

namespace TreemapChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];
            // Add a treemap chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Treemap, 50f, 50f, 500f, 400f);
            // Clear default data
            chart.ChartData.Categories.Clear();
            chart.ChartData.Series.Clear();
            // Get the chart data workbook
            Aspose.Slides.Charts.IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;
            wb.Clear(0);
            // Branch 1
            Aspose.Slides.Charts.IChartCategory leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C2", "Leaf 1"));
            leaf.GroupingLevels.SetGroupingItem(0, "Stem 1");
            leaf.GroupingLevels.SetGroupingItem(1, "Branch 1");
            chart.ChartData.Categories.Add(wb.GetCell(0, "C3", "Leaf 2"));
            leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C4", "Leaf 3"));
            leaf.GroupingLevels.SetGroupingItem(0, "Stem 2");
            chart.ChartData.Categories.Add(wb.GetCell(0, "C5", "Leaf 4"));
            // Branch 2
            leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C6", "Leaf 5"));
            leaf.GroupingLevels.SetGroupingItem(0, "Stem 3");
            leaf.GroupingLevels.SetGroupingItem(1, "Branch 2");
            chart.ChartData.Categories.Add(wb.GetCell(0, "C7", "Leaf 6"));
            leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C8", "Leaf 7"));
            leaf.GroupingLevels.SetGroupingItem(0, "Stem 4");
            chart.ChartData.Categories.Add(wb.GetCell(0, "C9", "Leaf 8"));
            // Add series
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(Aspose.Slides.Charts.ChartType.Treemap);
            series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
            series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D2", 10));
            series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D3", 20));
            series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D4", 30));
            series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D5", 40));
            series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D6", 50));
            series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D7", 60));
            series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D8", 70));
            series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D9", 80));
            // Set parent label layout
            series.ParentLabelLayout = Aspose.Slides.Charts.ParentLabelLayoutType.Overlapping;
            // Save the presentation
            pres.Save("TreemapChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}