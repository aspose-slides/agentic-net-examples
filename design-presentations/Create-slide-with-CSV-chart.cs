using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartFromCsvExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the CSV file
            string csvPath = "data.csv";

            // Verify that the CSV file exists
            if (!File.Exists(csvPath))
            {
                Console.WriteLine("CSV file not found: " + csvPath);
                return;
            }

            // Read all lines from the CSV
            string[] csvLines = File.ReadAllLines(csvPath);
            if (csvLines.Length < 2)
            {
                Console.WriteLine("CSV file does not contain enough data.");
                return;
            }

            // Parse header (first line) to get category names
            string[] headerParts = csvLines[0].Split(',');
            // First column is assumed to be the series name header, so categories start from index 1
            string[] categories = new string[headerParts.Length - 1];
            for (int i = 1; i < headerParts.Length; i++)
            {
                categories[i - 1] = headerParts[i].Trim();
            }

            // Parse series data
            int seriesCount = csvLines.Length - 1;
            string[] seriesNames = new string[seriesCount];
            double[,] values = new double[seriesCount, categories.Length];

            for (int r = 0; r < seriesCount; r++)
            {
                string[] rowParts = csvLines[r + 1].Split(',');
                if (rowParts.Length != headerParts.Length)
                {
                    Console.WriteLine("CSV row length mismatch at line " + (r + 2));
                    return;
                }

                seriesNames[r] = rowParts[0].Trim();

                for (int c = 1; c < rowParts.Length; c++)
                {
                    double parsedValue;
                    if (double.TryParse(rowParts[c].Trim(), out parsedValue))
                    {
                        values[r, c - 1] = parsedValue;
                    }
                    else
                    {
                        Console.WriteLine("Invalid numeric value at line " + (r + 2) + ", column " + (c + 1));
                        return;
                    }
                }
            }

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a new slide based on a predefined layout (Blank)
            ILayoutSlide layout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
            ISlide slide = presentation.Slides.AddEmptySlide(layout);

            try
            {
                // Add a clustered column chart to the slide
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

                // Remove default sample series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Get the chart data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Add categories
                for (int c = 0; c < categories.Length; c++)
                {
                    IChartDataCell categoryCell = workbook.GetCell(0, c + 1, 0, categories[c]);
                    chart.ChartData.Categories.Add(categoryCell);
                }

                // Add series and populate data points
                for (int s = 0; s < seriesCount; s++)
                {
                    IChartDataCell seriesCell = workbook.GetCell(0, 0, s + 1, seriesNames[s]);
                    IChartSeries series = chart.ChartData.Series.Add(seriesCell, chart.Type);

                    for (int c = 0; c < categories.Length; c++)
                    {
                        IChartDataCell valueCell = workbook.GetCell(0, c + 1, s + 1, values[s, c]);
                        series.DataPoints.AddDataPointForBarSeries(valueCell);
                    }

                    // Enable varied colors for the series (instead of using removed FillType)
                    series.ParentSeriesGroup.IsColorVaried = true;
                }

                // Optional: set chart title
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("Chart from CSV");
                chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
                chart.ChartTitle.Height = 20;

                // Save the presentation
                presentation.Save("ChartFromCsv_out.pptx", SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The requested file format is not supported by Aspose.Slides.
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URL failures)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                // Ensure resources are released
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}