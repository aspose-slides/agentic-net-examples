using System;
using System.IO;
using System.Text.Json;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var jsonPath = "data.json";
        var outputPath = "SunburstChart.pptx";

        if (!File.Exists(jsonPath))
        {
            Console.WriteLine($"JSON file not found: {jsonPath}");
            return;
        }

        Node hierarchy;
        try
        {
            var jsonContent = File.ReadAllText(jsonPath);
            hierarchy = JsonSerializer.Deserialize<Node>(jsonContent);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading JSON: {ex.Message}");
            return;
        }

        var presentation = new Aspose.Slides.Presentation();
        var slide = presentation.Slides[0];
        var chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Sunburst, 50, 50, 500, 400);
        chart.ChartData.Categories.Clear();
        chart.ChartData.Series.Clear();
        var workbook = chart.ChartData.ChartDataWorkbook;
        workbook.Clear(0);

        // Recursive addition of categories based on hierarchy
        void AddCategory(Node node, int level)
        {
            var leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, $"C{chart.ChartData.Categories.Count + 1}", node.Name));
            leaf.GroupingLevels.SetGroupingItem(level, node.Group ?? string.Empty);
            if (node.Children != null)
            {
                foreach (var child in node.Children)
                {
                    AddCategory(child, level + 1);
                }
            }
        }

        AddCategory(hierarchy, 0);

        var series = chart.ChartData.Series.Add(Aspose.Slides.Charts.ChartType.Sunburst);
        series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

        // Recursive addition of data points based on hierarchy
        void AddDataPoints(Node node)
        {
            series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, $"D{series.DataPoints.Count + 1}", node.Value));
            if (node.Children != null)
            {
                foreach (var child in node.Children)
                {
                    AddDataPoints(child);
                }
            }
        }

        AddDataPoints(hierarchy);

        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Format not supported or other save error
            Console.WriteLine($"Error saving presentation: {ex.Message}");
        }
    }

    // Model representing hierarchical JSON data
    public class Node
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public double Value { get; set; }
        public Node[] Children { get; set; }
    }
}