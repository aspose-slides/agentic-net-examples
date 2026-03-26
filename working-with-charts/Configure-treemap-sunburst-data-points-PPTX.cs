using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // -------------------- Treemap Chart --------------------
        Aspose.Slides.ISlide slide = pres.Slides[0];
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(ChartType.Treemap, 50f, 50f, 500f, 400f);
        chart.ChartData.Categories.Clear();
        chart.ChartData.Series.Clear();

        Aspose.Slides.Charts.IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;
        wb.Clear(0); // clear worksheet 0

        // Add categories (leaf nodes) with grouping levels
        Aspose.Slides.Charts.IChartCategory leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C1", "Leaf 1"));
        leaf.GroupingLevels.SetGroupingItem(0, "Stem 1");
        leaf.GroupingLevels.SetGroupingItem(1, "Branch 1");

        chart.ChartData.Categories.Add(wb.GetCell(0, "C2", "Leaf 2"));

        leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C3", "Leaf 3"));
        leaf.GroupingLevels.SetGroupingItem(0, "Stem 2");

        chart.ChartData.Categories.Add(wb.GetCell(0, "C4", "Leaf 4"));

        // Branch 2
        leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C5", "Leaf 5"));
        leaf.GroupingLevels.SetGroupingItem(0, "Stem 3");
        leaf.GroupingLevels.SetGroupingItem(1, "Branch 2");

        chart.ChartData.Categories.Add(wb.GetCell(0, "C6", "Leaf 6"));

        leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C7", "Leaf 7"));
        leaf.GroupingLevels.SetGroupingItem(0, "Stem 4");

        chart.ChartData.Categories.Add(wb.GetCell(0, "C8", "Leaf 8"));

        // Add series and data points
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(ChartType.Treemap);
        series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
        series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D1", 10.0));
        series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D2", 20.0));
        series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D3", 30.0));
        series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D4", 40.0));
        series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D5", 50.0));
        series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D6", 60.0));
        series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D7", 70.0));
        series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D8", 80.0));
        series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

        // -------------------- Sunburst Chart --------------------
        Aspose.Slides.ISlide slide2 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
        Aspose.Slides.Charts.IChart chart2 = slide2.Shapes.AddChart(ChartType.Sunburst, 50f, 50f, 500f, 400f);
        chart2.ChartData.Categories.Clear();
        chart2.ChartData.Series.Clear();

        Aspose.Slides.Charts.IChartDataWorkbook wb2 = chart2.ChartData.ChartDataWorkbook;
        wb2.Clear(0); // clear worksheet 0

        // Add categories with grouping levels
        Aspose.Slides.Charts.IChartCategory leaf2 = chart2.ChartData.Categories.Add(wb2.GetCell(0, "C1", "Leaf A"));
        leaf2.GroupingLevels.SetGroupingItem(0, "Stem A");
        leaf2.GroupingLevels.SetGroupingItem(1, "Branch A");

        chart2.ChartData.Categories.Add(wb2.GetCell(0, "C2", "Leaf B"));

        leaf2 = chart2.ChartData.Categories.Add(wb2.GetCell(0, "C3", "Leaf C"));
        leaf2.GroupingLevels.SetGroupingItem(0, "Stem B");

        chart2.ChartData.Categories.Add(wb2.GetCell(0, "C4", "Leaf D"));

        leaf2 = chart2.ChartData.Categories.Add(wb2.GetCell(0, "C5", "Leaf E"));
        leaf2.GroupingLevels.SetGroupingItem(0, "Stem C");
        leaf2.GroupingLevels.SetGroupingItem(1, "Branch B");

        chart2.ChartData.Categories.Add(wb2.GetCell(0, "C6", "Leaf F"));

        leaf2 = chart2.ChartData.Categories.Add(wb2.GetCell(0, "C7", "Leaf G"));
        leaf2.GroupingLevels.SetGroupingItem(0, "Stem D");

        chart2.ChartData.Categories.Add(wb2.GetCell(0, "C8", "Leaf H"));

        // Add series and data points
        Aspose.Slides.Charts.IChartSeries series2 = chart2.ChartData.Series.Add(ChartType.Sunburst);
        series2.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
        series2.DataPoints.AddDataPointForSunburstSeries(wb2.GetCell(0, "D1", 15.0));
        series2.DataPoints.AddDataPointForSunburstSeries(wb2.GetCell(0, "D2", 25.0));
        series2.DataPoints.AddDataPointForSunburstSeries(wb2.GetCell(0, "D3", 35.0));
        series2.DataPoints.AddDataPointForSunburstSeries(wb2.GetCell(0, "D4", 45.0));
        series2.DataPoints.AddDataPointForSunburstSeries(wb2.GetCell(0, "D5", 55.0));
        series2.DataPoints.AddDataPointForSunburstSeries(wb2.GetCell(0, "D6", 65.0));
        series2.DataPoints.AddDataPointForSunburstSeries(wb2.GetCell(0, "D7", 75.0));
        series2.DataPoints.AddDataPointForSunburstSeries(wb2.GetCell(0, "D8", 85.0));

        // Save the presentation
        string outputFile = "TreemapSunburstChart.pptx";
        pres.Save(outputFile, SaveFormat.Pptx);
        pres.Dispose();
    }
}