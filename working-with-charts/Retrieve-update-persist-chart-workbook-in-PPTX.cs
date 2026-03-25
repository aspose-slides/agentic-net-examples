using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartWorkbookDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define paths
            string dataDir = "Data";
            string workbookPath = Path.Combine(dataDir, "workbook.xlsx");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Verify that the external workbook exists
            if (!File.Exists(workbookPath))
            {
                Console.WriteLine("Error: Workbook file not found at " + workbookPath);
                return;
            }

            try
            {
                // Create a new presentation
                Presentation pres = new Presentation();

                // Add a pie chart to the first slide
                IChart chart = pres.Slides[0].Shapes.AddChart(
                    ChartType.Pie, 50, 50, 400, 600, true);

                // Access the chart data
                IChartData chartData = chart.ChartData;

                // Link the chart to the external workbook and update chart data
                ((ChartData)chartData).SetExternalWorkbook(workbookPath, true);

                // Retrieve the workbook associated with the chart
                IChartDataWorkbook workbook = chartData.ChartDataWorkbook;

                // Update a cell in the workbook (e.g., set A1 to a new label)
                workbook.GetCell(0, "A1", "Updated Category");

                // Save the presentation
                pres.Save(outputPath, SaveFormat.Pptx);

                Console.WriteLine("Presentation saved successfully to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}