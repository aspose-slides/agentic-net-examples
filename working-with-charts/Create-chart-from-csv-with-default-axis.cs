using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartFromCsv
{
    class Program
    {
        static void Main(string[] args)
        {
            string csvPath = "data.csv";
            string outputPath = "ReportChart.pptx";

            // Check if CSV file exists
            if (!File.Exists(csvPath))
            {
                Console.WriteLine("CSV file not found: " + csvPath);
                return;
            }

            try
            {
                // Read CSV lines
                string[] lines = File.ReadAllLines(csvPath);
                if (lines.Length < 2)
                {
                    Console.WriteLine("CSV file does not contain enough data.");
                    return;
                }

                // Split header
                string[] headerColumns = lines[0].Split(',');

                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a clustered column chart with default sample data
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);

                // Apply default axis setting (position axis between categories)
                chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

                // Access the chart data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add series (columns after the first one)
                for (int col = 1; col < headerColumns.Length; col++)
                {
                    string seriesName = headerColumns[col];
                    chart.ChartData.Series.Add(workbook.GetCell(0, 0, col, seriesName), chart.Type);
                }

                // Process each data row
                for (int row = 1; row < lines.Length; row++)
                {
                    string[] cells = lines[row].Split(',');

                    // Add category (first column)
                    string categoryName = cells[0];
                    chart.ChartData.Categories.Add(workbook.GetCell(0, row, 0, categoryName));

                    // Add data points for each series
                    for (int col = 1; col < headerColumns.Length; col++)
                    {
                        double value = 0;
                        Double.TryParse(cells[col], out value);
                        IChartSeries series = chart.ChartData.Series[col - 1];
                        series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, row, col, value));
                    }
                }

                // Optional: set a title
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("Report Chart");
                chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
                chart.ChartTitle.Height = 20;

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();

                Console.WriteLine("Chart created and saved to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors, parsing errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}