using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace HierarchicalDataPresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "source.pptx";
            string outputPath = "output.pptx";

            // Load existing presentation if it exists; otherwise create a new one
            Presentation pres;
            if (File.Exists(inputPath))
            {
                pres = new Presentation(inputPath);
            }
            else
            {
                pres = new Presentation();
            }

            // Get the first slide (a presentation always contains at least one slide)
            ISlide slide = pres.Slides[0];

            // Add a TreeMap chart to visualize hierarchical data
            float chartX = 50f;
            float chartY = 50f;
            float chartWidth = 500f;
            float chartHeight = 400f;
            IChart chart = slide.Shapes.AddChart(ChartType.Treemap, chartX, chartY, chartWidth, chartHeight);

            // Clear any default categories and series
            chart.ChartData.Categories.Clear();
            chart.ChartData.Series.Clear();

            // Get the workbook for adding custom data
            IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;
            wb.Clear(0); // Clear the first sheet

            int sheetIndex = 0;

            // ----- Branch 1 -----
            IChartCategory leaf = chart.ChartData.Categories.Add(wb.GetCell(sheetIndex, "C1", "Leaf 1"));
            leaf.GroupingLevels.SetGroupingItem(0, "Stem 1");
            leaf.GroupingLevels.SetGroupingItem(1, "Branch 1");

            chart.ChartData.Categories.Add(wb.GetCell(sheetIndex, "C2", "Leaf 2"));

            leaf = chart.ChartData.Categories.Add(wb.GetCell(sheetIndex, "C3", "Leaf 3"));
            leaf.GroupingLevels.SetGroupingItem(0, "Stem 2");

            chart.ChartData.Categories.Add(wb.GetCell(sheetIndex, "C4", "Leaf 4"));

            // ----- Branch 2 -----
            leaf = chart.ChartData.Categories.Add(wb.GetCell(sheetIndex, "C5", "Leaf 5"));
            leaf.GroupingLevels.SetGroupingItem(0, "Stem 3");
            leaf.GroupingLevels.SetGroupingItem(1, "Branch 2");

            chart.ChartData.Categories.Add(wb.GetCell(sheetIndex, "C6", "Leaf 6"));

            leaf = chart.ChartData.Categories.Add(wb.GetCell(sheetIndex, "C7", "Leaf 7"));
            leaf.GroupingLevels.SetGroupingItem(0, "Stem 4");

            chart.ChartData.Categories.Add(wb.GetCell(sheetIndex, "C8", "Leaf 8"));

            // Add a series and populate data points
            IChartSeries series = chart.ChartData.Series.Add(ChartType.Treemap);
            series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

            series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(sheetIndex, "D1", 10));
            series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(sheetIndex, "D2", 20));
            series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(sheetIndex, "D3", 15));
            series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(sheetIndex, "D4", 25));
            series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(sheetIndex, "D5", 30));
            series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(sheetIndex, "D6", 12));
            series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(sheetIndex, "D7", 18));
            series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(sheetIndex, "D8", 22));

            // Set parent label layout to overlapping
            series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

            // Save the presentation
            pres.Save(outputPath, SaveFormat.Pptx);

            // Clean up
            pres.Dispose();
        }
    }
}