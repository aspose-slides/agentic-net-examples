using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ExportChartDataToCsv
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define directories and file names
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string csvPath = Path.Combine(dataDir, "chartData.csv");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Ensure the data directory exists
            if (!Directory.Exists(dataDir))
            {
                Console.WriteLine("Data directory does not exist: " + dataDir);
                return;
            }

            // Verify that the input presentation exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Assume the first shape is a chart
                IChart chart = slide.Shapes[0] as IChart;
                if (chart == null)
                {
                    Console.WriteLine("No chart found on the first slide.");
                    pres.Dispose();
                    return;
                }

                // Open CSV file for writing
                using (StreamWriter writer = new StreamWriter(csvPath, false))
                {
                    // Write CSV header
                    writer.WriteLine("Series,Category,Value");

                    // Iterate through categories (rows)
                    for (int catIndex = 0; catIndex < chart.ChartData.Categories.Count; catIndex++)
                    {
                        // Get category name (may be a string chart value)
                        IStringChartValue catNameValue = chart.ChartData.Categories[catIndex].Value as IStringChartValue;
                        string categoryName = catNameValue != null ? catNameValue.ToString() : string.Empty;

                        // Iterate through each series (columns)
                        for (int serIndex = 0; serIndex < chart.ChartData.Series.Count; serIndex++)
                        {
                            IChartSeries series = chart.ChartData.Series[serIndex];

                            // Get series name (handle IStringChartValue correctly)
                            IStringChartValue serNameValue = series.Name as IStringChartValue;
                            string seriesName = serNameValue != null ? serNameValue.ToString() : string.Empty;

                            // Get the data point value
                            object dataObj = series.DataPoints[catIndex].Value.Data;
                            string dataValue = dataObj != null ? dataObj.ToString() : string.Empty;

                            // Write CSV line
                            writer.WriteLine($"{EscapeCsv(seriesName)},{EscapeCsv(categoryName)},{EscapeCsv(dataValue)}");
                        }
                    }
                }

                // Save the (potentially unchanged) presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();

                Console.WriteLine("Chart data exported to CSV successfully.");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported by Aspose.Slides.
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        // Helper method to escape CSV fields
        private static string EscapeCsv(string field)
        {
            if (field == null)
                return string.Empty;

            if (field.Contains(",") || field.Contains("\"") || field.Contains("\n"))
            {
                string escaped = field.Replace("\"", "\"\"");
                return $"\"{escaped}\"";
            }
            else
            {
                return field;
            }
        }
    }
}