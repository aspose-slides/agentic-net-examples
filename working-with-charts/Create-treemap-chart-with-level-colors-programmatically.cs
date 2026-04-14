using System;
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a treemap chart to the first slide
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Treemap, 50f, 50f, 500f, 400f);

            // Remove default sample data
            chart.ChartData.Categories.Clear();
            chart.ChartData.Series.Clear();

            // Add a series first (required to avoid ArgumentException)
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
                Aspose.Slides.Charts.ChartType.Treemap);

            // Set parent label layout (optional)
            series.ParentLabelLayout = Aspose.Slides.Charts.ParentLabelLayoutType.Overlapping;

            // Workbook for creating cells
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // ----- Define hierarchical categories -----
            // Level 0: Stem A
            Aspose.Slides.Charts.IChartCategory stemA = chart.ChartData.Categories.Add(
                workbook.GetCell(0, 0, 0, "Stem A"));
            stemA.GroupingLevels.SetGroupingItem(0, "Stem A");

            // Level 1: Branch A1 under Stem A
            Aspose.Slides.Charts.IChartCategory branchA1 = chart.ChartData.Categories.Add(
                workbook.GetCell(0, 1, 0, "Branch A1"));
            branchA1.GroupingLevels.SetGroupingItem(0, "Stem A");
            branchA1.GroupingLevels.SetGroupingItem(1, "Branch A1");

            // Level 2: Leaf 1 under Branch A1
            Aspose.Slides.Charts.IChartCategory leaf1 = chart.ChartData.Categories.Add(
                workbook.GetCell(0, 2, 0, "Leaf 1"));
            leaf1.GroupingLevels.SetGroupingItem(0, "Stem A");
            leaf1.GroupingLevels.SetGroupingItem(1, "Branch A1");

            // Add size values for each leaf
            series.DataPoints.AddDataPointForTreemapSeries(
                workbook.GetCell(0, 0, 1, 30));
            series.DataPoints.AddDataPointForTreemapSeries(
                workbook.GetCell(0, 1, 1, 20));
            series.DataPoints.AddDataPointForTreemapSeries(
                workbook.GetCell(0, 2, 1, 50));

            // ----- Assign distinct colors to each hierarchical level -----
            // Level 0 (Stem) – LightBlue
            Aspose.Slides.Charts.IChartDataPointLevel level0 = series.DataPoints[0].DataPointLevels[0];
            level0.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
            level0.Format.Fill.SolidFillColor.Color = System.Drawing.Color.LightBlue;

            // Level 1 (Branch) – LightGreen
            Aspose.Slides.Charts.IChartDataPointLevel level1 = series.DataPoints[0].DataPointLevels[1];
            level1.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
            level1.Format.Fill.SolidFillColor.Color = System.Drawing.Color.LightGreen;

            // Save the presentation
            presentation.Save("TreemapChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported – handle accordingly
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}