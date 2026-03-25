using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace TreeMapChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation pres = new Presentation();

                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a TreeMap chart
                IChart chart = slide.Shapes.AddChart(ChartType.Treemap, 50f, 50f, 500f, 400f);

                // Clear default categories and series
                chart.ChartData.Categories.Clear();
                chart.ChartData.Series.Clear();

                // Get the chart data workbook
                IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;
                wb.Clear(0);

                // Branch 1
                IChartCategory leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C1", "Leaf 1"));
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

                // Add a series for the TreeMap chart
                IChartSeries series = chart.ChartData.Series.Add(ChartType.Treemap);
                series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

                // Add data points (size values)
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
                string outputFile = "TreeMapChartOutput.pptx";
                pres.Save(outputFile, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}