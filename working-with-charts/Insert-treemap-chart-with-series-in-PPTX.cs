using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

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
                chart.ChartData.Categories.Clear();
                chart.ChartData.Series.Clear();

                // Get the chart data workbook
                IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;
                wb.Clear(0);

                // Branch 1
                IChartCategory leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "B2", "Leaf 1"));
                leaf.GroupingLevels.SetGroupingItem(1, "Stem 1");
                leaf.GroupingLevels.SetGroupingItem(2, "Branch 1");
                chart.ChartData.Categories.Add(wb.GetCell(0, "B3", "Leaf 2"));
                leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "B4", "Leaf 3"));
                leaf.GroupingLevels.SetGroupingItem(1, "Stem 2");
                chart.ChartData.Categories.Add(wb.GetCell(0, "B5", "Leaf 4"));

                // Branch 2
                leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "B6", "Leaf 5"));
                leaf.GroupingLevels.SetGroupingItem(1, "Stem 3");
                leaf.GroupingLevels.SetGroupingItem(2, "Branch 2");
                chart.ChartData.Categories.Add(wb.GetCell(0, "B7", "Leaf 6"));
                leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "B8", "Leaf 7"));
                leaf.GroupingLevels.SetGroupingItem(1, "Stem 4");
                chart.ChartData.Categories.Add(wb.GetCell(0, "B9", "Leaf 8"));

                // Add series and data points
                IChartSeries series = chart.ChartData.Series.Add(ChartType.Treemap);
                series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
                series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "C2", 10));
                series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "C3", 20));
                series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "C4", 30));
                series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "C5", 40));
                series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "C6", 50));
                series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "C7", 60));
                series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "C8", 70));
                series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "C9", 80));

                // Set parent label layout
                series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

                // Save the presentation
                pres.Save("TreeMapChart.pptx", SaveFormat.Pptx);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Console.WriteLine("Input file not found: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}