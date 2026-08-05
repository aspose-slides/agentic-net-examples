// -----------------------------------------------------------------------------
// Example: Export chart data to CSV using C#
//
// Description:
// Demonstrates how to export chart data from the first chart on the first slide
// of a PowerPoint presentation to a CSV file using C# and Aspose.Slides for 
// .NET. The example loads a PPTX file, accesses the chart's internal workbook,
// iterates through its cells, and writes the data to a CSV file. It also shows
// basic error handling and ensures the presentation is saved before exiting.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, Chart, Data, CSV, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate export of chart data to CSV for reporting or analysis.
// - Build C# utilities for PowerPoint presentation data extraction.
// - Integrate chart data export into .NET applications handling PPTX files.
// - Validate and verify chart contents during presentation workflow automation.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Paths for input presentation and output CSV
        string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        string presentationPath = Path.Combine(dataDir, "input.pptx");
        string csvOutputPath = Path.Combine(dataDir, "chartData.csv");

        // Verify that the presentation file exists
        if (!File.Exists(presentationPath))
        {
            Console.WriteLine("Presentation file not found: " + presentationPath);
            return;
        }

        // Load the presentation
        Presentation pres = null;
        try
        {
            pres = new Presentation(presentationPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        // Get the first chart on the first slide
        IChart chart = pres.Slides[0].Shapes[0] as IChart;
        if (chart == null)
        {
            Console.WriteLine("No chart found on the first slide.");
            // Save presentation before exiting
            try
            {
                pres.Save(presentationPath, SaveFormat.Pptx);
            }
            catch (Exception saveEx)
            {
                // Format not supported
                Console.WriteLine("Error saving presentation: " + saveEx.Message);
            }
            finally
            {
                pres.Dispose();
            }
            return;
        }

        // Access the chart's internal workbook
        IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Export workbook data to CSV (first worksheet only)
        try
        {
            using (StreamWriter writer = new StreamWriter(csvOutputPath, false))
            {
                int maxRows = 100;   // Adjust as needed
                int maxCols = 20;    // Adjust as needed

                for (int row = 0; row < maxRows; row++)
                {
                    string[] rowValues = new string[maxCols];
                    bool hasData = false;

                    for (int col = 0; col < maxCols; col++)
                    {
                        IChartDataCell cell = workbook.GetCell(0, row, col);
                        if (cell != null && cell.Value != null)
                        {
                            rowValues[col] = cell.Value.ToString();
                            hasData = true;
                        }
                        else
                        {
                            rowValues[col] = string.Empty;
                        }
                    }

                    if (!hasData)
                    {
                        // Assume no more data in the worksheet
                        break;
                    }

                    writer.WriteLine(string.Join(",", rowValues));
                }
            }

            Console.WriteLine("Chart data exported to CSV: " + csvOutputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error exporting chart data to CSV: " + ex.Message);
        }

        // Save the presentation before exit
        try
        {
            pres.Save(presentationPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Format not supported
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
        finally
        {
            pres.Dispose();
        }
    }
}
