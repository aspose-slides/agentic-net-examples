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
            if (!File.Exists(csvPath))
            {
                Console.WriteLine("CSV file not found: " + csvPath);
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation())
                {
                    ISlide slide = presentation.Slides[0];
                    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
                    // Apply default axis setting
                    chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

                    // Read CSV data
                    string[] lines = File.ReadAllLines(csvPath);
                    if (lines.Length < 2)
                    {
                        Console.WriteLine("CSV file does not contain sufficient data.");
                    }
                    else
                    {
                        // First line contains headers: first column is category, rest are series names
                        string[] headers = lines[0].Split(',');

                        int seriesCount = headers.Length - 1;
                        IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                        int defaultWorksheetIndex = 0;

                        // Clear default sample data
                        chart.ChartData.Series.Clear();
                        chart.ChartData.Categories.Clear();

                        // Add series
                        for (int i = 0; i < seriesCount; i++)
                        {
                            string seriesName = headers[i + 1];
                            chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, i + 1, seriesName), chart.Type);
                        }

                        // Add categories and data points
                        for (int row = 1; row < lines.Length; row++)
                        {
                            string[] columns = lines[row].Split(',');
                            if (columns.Length != headers.Length)
                                continue; // Skip malformed rows

                            string categoryName = columns[0];
                            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, row, 0, categoryName));

                            for (int col = 1; col < columns.Length; col++)
                            {
                                double value;
                                if (!double.TryParse(columns[col], out value))
                                    value = 0;

                                IChartSeries series = chart.ChartData.Series[col - 1];
                                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, row, col, value));
                            }
                        }
                    }

                    string outputPath = "ChartFromCsv.pptx";
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}