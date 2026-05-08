using System;
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
            var pres = new Aspose.Slides.Presentation();

            // Access the first slide
            var slide = pres.Slides[0];

            // Add a clustered column chart
            var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Clear default categories and series
            chart.ChartData.Categories.Clear();
            chart.ChartData.Series.Clear();

            // Get the chart data workbook
            var wb = chart.ChartData.ChartDataWorkbook;
            wb.Clear(0);

            // Add multi-level categories
            // Category: Region -> Country
            var leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C2", "USA"));
            leaf.GroupingLevels.SetGroupingItem(0, "North America");
            leaf.GroupingLevels.SetGroupingItem(1, "USA");

            leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C3", "Canada"));
            leaf.GroupingLevels.SetGroupingItem(0, "North America");
            leaf.GroupingLevels.SetGroupingItem(1, "Canada");

            leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C4", "Germany"));
            leaf.GroupingLevels.SetGroupingItem(0, "Europe");
            leaf.GroupingLevels.SetGroupingItem(1, "Germany");

            leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C5", "France"));
            leaf.GroupingLevels.SetGroupingItem(0, "Europe");
            leaf.GroupingLevels.SetGroupingItem(1, "France");

            // Add a series
            var series = chart.ChartData.Series.Add(wb.GetCell(0, "D1", "Sales"), chart.Type);
            series.DataPoints.AddDataPointForBarSeries(wb.GetCell(0, "D2", 12000));
            series.DataPoints.AddDataPointForBarSeries(wb.GetCell(0, "D3", 15000));
            series.DataPoints.AddDataPointForBarSeries(wb.GetCell(0, "D4", 18000));
            series.DataPoints.AddDataPointForBarSeries(wb.GetCell(0, "D5", 13000));

            // Save the presentation
            pres.Save("MultiLevelCategoryChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}