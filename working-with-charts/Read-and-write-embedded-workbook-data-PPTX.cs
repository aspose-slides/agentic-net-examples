using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartDataUpdate
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                using (Presentation pres = new Presentation(inputPath))
                {
                    IChart chart = pres.Slides[0].Shapes[0] as IChart;
                    if (chart != null)
                    {
                        IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                        // Update a cell in the embedded workbook (e.g., cell A1)
                        workbook.GetCell(0, "A1", 200);

                        // Recalculate any formulas in the workbook
                        workbook.CalculateFormulas();

                        // Optionally, update the chart data point directly
                        if (chart.ChartData.Series.Count > 0 && chart.ChartData.Series[0].DataPoints.Count > 0)
                        {
                            chart.ChartData.Series[0].DataPoints[0].Value.Data = 200;
                        }
                    }

                    pres.Save(outputPath, SaveFormat.Pptx);
                }

                Console.WriteLine("Presentation saved successfully to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}