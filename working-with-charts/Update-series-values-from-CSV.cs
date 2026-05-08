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