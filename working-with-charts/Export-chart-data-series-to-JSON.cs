using System;
using System.IO;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ExportChartDataToJson
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path for the output presentation and JSON file
            string presentationPath = "ChartExport.pptx";
            string jsonPath = "ChartData.json";

            try
            {
                // Create a new presentation
                using (Presentation pres = new Presentation())
                {
                    // Access the first slide
                    ISlide slide = pres.Slides[0];

                    // Add a clustered column chart with sample data
                    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 0f, 0f, 500f, 400f);

                    // Clear default series and categories
                    chart.ChartData.Series.Clear();
                    chart.ChartData.Categories.Clear();

                    // Get the chart data workbook
                    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                    // Add two series
                    IChartSeries series1 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), ChartType.ClusteredColumn);
                    IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), ChartType.ClusteredColumn);

                    // Add three categories
                    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
                    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
                    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

                    // Populate series data using literal double values (correct type)
                    series1.DataPoints.AddDataPointForBarSeries(20.0);
                    series1.DataPoints.AddDataPointForBarSeries(50.0);
                    series1.DataPoints.AddDataPointForBarSeries(30.0);

                    series2.DataPoints.AddDataPointForBarSeries(30.0);
                    series2.DataPoints.AddDataPointForBarSeries(10.0);
                    series2.DataPoints.AddDataPointForBarSeries(60.0);

                    // Export chart data series to JSON
                    ExportChartSeriesToJson(chart, jsonPath);

                    // Save the presentation
                    pres.Save(presentationPath, SaveFormat.Pptx);
                }

                Console.WriteLine("Presentation saved to " + presentationPath);
                Console.WriteLine("Chart data exported to " + jsonPath);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found: " + ex.Message);
            }
            catch (NotSupportedException ex)
            {
                // Format not supported
                Console.WriteLine("The requested file format is not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., external URLs or web services)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        // Exports each series name and its data points to a JSON file
        private static void ExportChartSeriesToJson(IChart chart, string jsonFilePath)
        {
            // Create a serializable structure
            var chartData = new System.Collections.Generic.List<SeriesData>();

            // Iterate over each series
            foreach (IChartSeries series in chart.ChartData.Series)
            {
                // Get series name
                string seriesName = series.Name.ToString();

                // Collect data point values
                var values = new System.Collections.Generic.List<double>();
                foreach (IChartDataPoint point in series.DataPoints)
                {
                    // Value is IDoubleChartValue; convert to double
                    double numericValue = point.Value.ToDouble();
                    values.Add(numericValue);
                }

                // Add to list
                chartData.Add(new SeriesData { Name = seriesName, Values = values });
            }

            // Serialize to JSON with indentation
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(chartData, options);

            // Write JSON to file
            File.WriteAllText(jsonFilePath, jsonString);
        }

        // Helper class for JSON serialization
        private class SeriesData
        {
            public string Name { get; set; }
            public System.Collections.Generic.List<double> Values { get; set; }
        }
    }
}