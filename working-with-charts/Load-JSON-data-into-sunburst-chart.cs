using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SunburstChartFromJson
{
    // Model representing hierarchical data
    public class Node
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public List<Node> Children { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Path to the JSON file containing hierarchical data
            string jsonPath = "hierarchy.json";

            // Verify that the JSON file exists
            if (!File.Exists(jsonPath))
            {
                Console.WriteLine("Input JSON file not found: " + jsonPath);
                return;
            }

            // Read and deserialize JSON data
            string jsonContent = File.ReadAllText(jsonPath);
            List<Node> rootNodes = JsonSerializer.Deserialize<List<Node>>(jsonContent);

            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a Sunburst chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.Sunburst, 50, 50, 600, 400);

            // Clear any default categories and series
            chart.ChartData.Categories.Clear();
            chart.ChartData.Series.Clear();

            // Get the workbook to store category and value cells
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            workbook.Clear(0);

            // Lists to keep track of leaf nodes for data points
            List<Node> leafNodes = new List<Node>();

            // Row counters for cells
            int categoryRow = 0;
            int valueRow = 0;

            // Helper method to add a category cell
            void AddCategory(string cellRef, string categoryName, Action<IChartCategory> configure = null)
            {
                IChartCategory category = chart.ChartData.Categories.Add(workbook.GetCell(0, cellRef, categoryName));
                configure?.Invoke(category);
                categoryRow++;
            }

            // Process hierarchical data and build categories with grouping levels
            foreach (Node root in rootNodes)
            {
                // Root level category (no grouping)
                AddCategory($"C{categoryRow + 1}", root.Name);

                if (root.Children != null)
                {
                    foreach (Node branch in root.Children)
                    {
                        // Branch level category, grouped under root
                        AddCategory($"C{categoryRow + 1}", branch.Name, cat =>
                        {
                            cat.GroupingLevels.SetGroupingItem(1, root.Name);
                        });

                        if (branch.Children != null)
                        {
                            foreach (Node leaf in branch.Children)
                            {
                                // Leaf level category, grouped under root and branch
                                AddCategory($"C{categoryRow + 1}", leaf.Name, cat =>
                                {
                                    cat.GroupingLevels.SetGroupingItem(1, root.Name);
                                    cat.GroupingLevels.SetGroupingItem(2, branch.Name);
                                });
                                leafNodes.Add(leaf);
                            }
                        }
                    }
                }
            }

            // Add a series for the Sunburst chart
            IChartSeries series = chart.ChartData.Series.Add(ChartType.Sunburst);
            series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

            // Add data points for each leaf node using its Value
            foreach (Node leaf in leafNodes)
            {
                // Create a cell for the size/value of the data point
                IChartDataCell valueCell = workbook.GetCell(0, $"D{valueRow + 1}", leaf.Value);
                series.DataPoints.AddDataPointForSunburstSeries(valueCell);
                valueRow++;
            }

            // Save the presentation
            string outputPath = "SunburstChartFromJson.pptx";
            try
            {
                presentation.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved successfully: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle cases where the format is not supported
                // Format not supported.
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}