using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a Treemap chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Treemap, 0f, 0f, 500f, 400f);

        // Clear default categories and series
        chart.ChartData.Categories.Clear();
        chart.ChartData.Series.Clear();

        // Get the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;
        wb.Clear(0);

        // Branch 1
        Aspose.Slides.Charts.IChartCategory leaf = chart.ChartData.Categories.Add(
            wb.GetCell(0, "C1", "Leaf1"));
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

        // Add a series for the Treemap
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
            Aspose.Slides.Charts.ChartType.Treemap);
        series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

        // Add data points (size values) for the series
        series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D1", 10));
        series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D2", 20));
        series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D3", 30));
        series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D4", 40));
        series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D5", 50));
        series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D6", 60));
        series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D7", 70));
        series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D8", 80));

        // Set parent label layout
        series.ParentLabelLayout = Aspose.Slides.Charts.ParentLabelLayoutType.Overlapping;

        // Save the presentation
        pres.Save("TreemapChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}