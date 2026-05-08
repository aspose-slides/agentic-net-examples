using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AddCustomTooltip
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output path
            string outputPath = "CustomTooltipChart.pptx";

            // Ensure any existing file is overwritten safely
            if (File.Exists(outputPath))
            {
                try
                {
                    File.Delete(outputPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unable to delete existing file: " + ex.Message);
                    return;
                }
            }

            try
            {
                // Create a new presentation
                using (Presentation pres = new Presentation())
                {
                    // Add a pie chart to the first slide
                    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50f, 50f, 600f, 400f, true);

                    // Access the first series of the chart
                    IChartSeries series = chart.ChartData.Series[0];

                    // Configure the series to accept double literals for values
                    series.DataPoints.DataSourceTypeForValues = DataSourceType.DoubleLiterals;

                    // Sample data values
                    double[] values = new double[] { 30.0, 45.0, 25.0 };
                    string[] categories = new string[] { "Category A", "Category B", "Category C" };

                    // Add categories to the chart
                    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                    for (int i = 0; i < categories.Length; i++)
                    {
                        chart.ChartData.Categories.Add(workbook.GetCell(0, i + 1, 0, categories[i]));
                    }

                    // Add data points and assign custom tooltips
                    for (int i = 0; i < values.Length; i++)
                    {
                        IChartDataPoint point = series.DataPoints.AddDataPointForPieSeries(values[i]);

                        // Set a custom tooltip (displayed as data label text)
                        string tooltipText = $"Value: {values[i]}, Category: {categories[i]}";
                        point.Label.AddTextFrameForOverriding(tooltipText);
                    }

                    // Save the presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }

                Console.WriteLine("Presentation saved successfully to " + outputPath);
            }
            catch (ArgumentException argEx)
            {
                // Handle specific Aspose.Slides argument errors (e.g., unsupported data source type)
                Console.WriteLine("Argument error: " + argEx.Message);
            }
            catch (NotSupportedException nsEx)
            {
                // Handle unsupported file format
                // Format not supported
                Console.WriteLine("Format not supported: " + nsEx.Message);
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}