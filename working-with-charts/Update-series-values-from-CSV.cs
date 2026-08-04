// -----------------------------------------------------------------------------
// Example: Update series values from CSV using C#
//
// Description:
// Demonstrates how to read data from a CSV file and use it to populate a
// pie chart series in a PowerPoint presentation with Aspose.Slides for .NET.
// The example creates a new presentation, adds a pie chart, clears default
// data, fills categories and data points from the CSV, and saves the result.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, CSV, Pie Chart, Series, Values,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Generate pie charts from external CSV data.
// - Automate PowerPoint report creation with dynamic data.
// - Build .NET tools for chart data updates in PPTX files.
// - Integrate CSV-driven chart generation into business workflows.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var csvPath = "data.csv";
        if (!File.Exists(csvPath))
        {
            Console.WriteLine("CSV file not found.");
            return;
        }

        try
        {
            var presentation = new Aspose.Slides.Presentation();
            var slide = presentation.Slides[0];

            // Add a pie chart with sample data
            var chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Pie,
                50, 50, 400, 600, true);

            var chartData = chart.ChartData;

            // Remove default series and categories
            chartData.Series.Clear();
            chartData.Categories.Clear();

            // Create a new series
            var defaultWorksheetIndex = 0;
            var workbook = chartData.ChartDataWorkbook;
            var series = chartData.Series.Add(
                workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"),
                chart.Type);

            // Read CSV and populate categories and data points
            var lines = File.ReadAllLines(csvPath);
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length < 2) continue;

                var category = parts[0];
                if (!double.TryParse(parts[1], out var value)) continue;

                // Add category
                var categoryIndex = chartData.Categories.Count;
                chartData.Categories.Add(
                    workbook.GetCell(defaultWorksheetIndex, categoryIndex + 1, 0, category));

                // Add data point to the series
                series.DataPoints.AddDataPointForPieSeries(value);
            }

            // Save the presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (InvalidOperationException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
