using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ExtractChartDataTable
{
    class Program
    {
        static void Main(string[] args)
        {
            string presentationPath = "input.pptx";
            string outputExcelPath = "ChartData.xlsx";

            // Verify that the input presentation exists
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Presentation file not found: " + presentationPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(presentationPath))
                {
                    // Find the first chart shape in the presentation
                    IChart chart = null;
                    foreach (IShape shape in pres.Slides[0].Shapes)
                    {
                        chart = shape as IChart;
                        if (chart != null)
                            break;
                    }

                    if (chart == null)
                    {
                        Console.WriteLine("No chart found in the first slide.");
                        return;
                    }

                    // Ensure the chart has a data table (optional, based on requirement)
                    chart.HasDataTable = true;

                    // Access the embedded workbook that holds the chart data
                    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                    // Export the internal workbook to an Excel file
                    // The chart data is stored in an internal workbook; retrieve it as a stream
                    ChartData chartData = chart.ChartData as ChartData;
                    if (chartData == null)
                    {
                        Console.WriteLine("Unable to cast ChartData.");
                        return;
                    }

                    using (MemoryStream ms = chartData.ReadWorkbookStream())
                    {
                        // Write the stream to an .xlsx file
                        using (FileStream fileStream = new FileStream(outputExcelPath, FileMode.Create, FileAccess.Write))
                        {
                            ms.WriteTo(fileStream);
                        }
                    }

                    // Save the presentation (as required)
                    pres.Save("output.pptx", SaveFormat.Pptx);
                }

                Console.WriteLine("Chart data exported to: " + outputExcelPath);
            }
            catch (NotSupportedException)
            {
                // Handle unsupported file format
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}