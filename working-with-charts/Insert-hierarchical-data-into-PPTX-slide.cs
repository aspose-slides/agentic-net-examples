using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace HierarchicalDataPresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "template.pptx";
            string outputPath = "HierarchicalData_out.pptx";

            Aspose.Slides.Presentation presentation = null;

            try
            {
                if (File.Exists(inputPath))
                {
                    presentation = new Aspose.Slides.Presentation(inputPath);
                }
                else
                {
                    // Input file not found – create a new presentation
                    presentation = new Aspose.Slides.Presentation();
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Input file not found: " + ex.Message);
                // Create a new presentation as fallback
                presentation = new Aspose.Slides.Presentation();
            }

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a TreeMap chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Treemap,
                50f, 50f, 500f, 400f);

            // Clear default categories and series
            chart.ChartData.Categories.Clear();
            chart.ChartData.Series.Clear();

            // Clear the workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            workbook.Clear(0);

            // Branch 1
            Aspose.Slides.Charts.IChartCategory leaf = chart.ChartData.Categories.Add(
                workbook.GetCell(0, "C1", "Leaf 1"));
            leaf.GroupingLevels.SetGroupingItem(0, "Stem A");
            leaf.GroupingLevels.SetGroupingItem(1, "Branch A1");

            chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf 2"));

            leaf = chart.ChartData.Categories.Add(
                workbook.GetCell(0, "C3", "Leaf 3"));
            leaf.GroupingLevels.SetGroupingItem(0, "Stem B");
            chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf 4"));

            // Branch 2
            leaf = chart.ChartData.Categories.Add(
                workbook.GetCell(0, "C5", "Leaf 5"));
            leaf.GroupingLevels.SetGroupingItem(0, "Stem C");
            leaf.GroupingLevels.SetGroupingItem(1, "Branch C1");

            chart.ChartData.Categories.Add(workbook.GetCell(0, "C6", "Leaf 6"));

            leaf = chart.ChartData.Categories.Add(
                workbook.GetCell(0, "C7", "Leaf 7"));
            leaf.GroupingLevels.SetGroupingItem(0, "Stem D");

            chart.ChartData.Categories.Add(workbook.GetCell(0, "C8", "Leaf 8"));

            // Add series and data points
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(Aspose.Slides.Charts.ChartType.Treemap);
            series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

            series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D1", 10));
            series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D2", 20));
            series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D3", 30));
            series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D4", 40));
            series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D5", 50));
            series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D6", 60));
            series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D7", 70));
            series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D8", 80));

            series.ParentLabelLayout = Aspose.Slides.Charts.ParentLabelLayoutType.Overlapping;

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}