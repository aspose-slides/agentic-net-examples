// -----------------------------------------------------------------------------
// Example: Load CSV data into sunburst chart series using C#
//
// Description:
// Demonstrates how to read a CSV file containing category names and size
// values, and populate a Sunburst chart series in a PowerPoint presentation
// using Aspose.Slides for .NET. The example creates a new presentation, adds a
// Sunburst chart, maps CSV rows to chart categories and data points, and saves
// the result as a PPTX file. This pattern can be used to automate chart data
// loading, generate dynamic presentations, or validate chart content.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, CSV, Load, Data, Sunburst, Chart,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate loading CSV data into Sunburst chart series.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files with chart data in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SunburstChartFromCsv
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the CSV file
            string csvPath = "data.csv";
            // Output presentation file
            string outputPath = "SunburstChart.pptx";

            // Check if CSV file exists
            if (!File.Exists(csvPath))
            {
                Console.WriteLine("CSV file not found: " + csvPath);
                return;
            }

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a Sunburst chart
                IChart chart = slide.Shapes.AddChart(ChartType.Sunburst, 50f, 50f, 500f, 400f);

                // Clear default categories and series
                chart.ChartData.Categories.Clear();
                chart.ChartData.Series.Clear();

                // Get the workbook to create cells
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                workbook.Clear(0);

                // Read CSV lines
                string[] lines = File.ReadAllLines(csvPath);
                int rowIndex = 0;
                foreach (string line in lines)
                {
                    // Skip empty lines
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    // Expected format: Category,SizeValue
                    string[] parts = line.Split(',');
                    if (parts.Length < 2)
                        continue; // Invalid line, skip

                    string categoryName = parts[0].Trim();
                    string sizeValueString = parts[1].Trim();
                    double sizeValue;
                    if (!double.TryParse(sizeValueString, out sizeValue))
                        continue; // Invalid size, skip

                    // Add category cell (column C)
                    string categoryCellRef = "C" + (rowIndex + 1).ToString();
                    chart.ChartData.Categories.Add(workbook.GetCell(0, categoryCellRef, categoryName));

                    // Add size value cell (column D)
                    string valueCellRef = "D" + (rowIndex + 1).ToString();
                    workbook.GetCell(0, valueCellRef, sizeValue);

                    rowIndex++;
                }

                // Add a series for Sunburst chart
                IChartSeries series = chart.ChartData.Series.Add(ChartType.Sunburst);
                series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

                // Add data points for each size value
                for (int i = 0; i < rowIndex; i++)
                {
                    string valueCellRef = "D" + (i + 1).ToString();
                    IChartDataCell sizeCell = workbook.GetCell(0, valueCellRef, 0.0);
                    series.DataPoints.AddDataPointForSunburstSeries(sizeCell);
                }

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (InvalidOperationException ex)
            {
                // Handle unsupported format or other Aspose.Slides specific errors
                Console.WriteLine("Operation failed: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
