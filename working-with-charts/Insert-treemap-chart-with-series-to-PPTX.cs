using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputFile = "TreeMapChart.pptx";

        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        Aspose.Slides.ISlide slide = pres.Slides[0];

        var chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Treemap, 50, 50, 500, 400);

        chart.ChartData.Categories.Clear();
        chart.ChartData.Series.Clear();

        var wb = chart.ChartData.ChartDataWorkbook;
        wb.Clear(0);

        var leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C1", "Leaf 1"));
        leaf.GroupingLevels.SetGroupingItem(1, "Stem 1");
        leaf.GroupingLevels.SetGroupingItem(2, "Branch 1");
        chart.ChartData.Categories.Add(wb.GetCell(0, "C2", "Leaf 2"));
        leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C3", "Leaf 3"));
        leaf.GroupingLevels.SetGroupingItem(1, "Stem 2");
        chart.ChartData.Categories.Add(wb.GetCell(0, "C4", "Leaf 4"));
        leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C5", "Leaf 5"));
        leaf.GroupingLevels.SetGroupingItem(1, "Stem 3");
        leaf.GroupingLevels.SetGroupingItem(2, "Branch 2");
        chart.ChartData.Categories.Add(wb.GetCell(0, "C6", "Leaf 6"));
        leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C7", "Leaf 7"));
        leaf.GroupingLevels.SetGroupingItem(1, "Stem 4");
        chart.ChartData.Categories.Add(wb.GetCell(0, "C8", "Leaf 8"));

        var series = chart.ChartData.Series.Add(Aspose.Slides.Charts.ChartType.Treemap);
        series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
        series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D1", 10));
        series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D2", 20));
        series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D3", 30));
        series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D4", 40));
        series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D5", 50));
        series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D6", 60));
        series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D7", 70));
        series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D8", 80));
        series.ParentLabelLayout = Aspose.Slides.Charts.ParentLabelLayoutType.Overlapping;

        pres.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}