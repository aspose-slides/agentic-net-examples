using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ExternalWorkbookChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define paths
            string dataDirectory = Directory.GetCurrentDirectory();
            string workbookPath = Path.Combine(dataDirectory, "data.xlsx");
            string outputPath = Path.Combine(dataDirectory, "output.pptx");

            // Verify that the external workbook exists
            if (!File.Exists(workbookPath))
            {
                Console.WriteLine("Error: Workbook file not found at " + workbookPath);
                return;
            }

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add a pie chart to the first slide
                IChart chart = presentation.Slides[0].Shapes.AddChart(
                    ChartType.Pie, 50, 50, 400, 600, true);

                // Get the chart data object
                IChartData chartData = chart.ChartData;

                // Set the external workbook as data source (do not update chart data immediately)
                ((ChartData)chartData).SetExternalWorkbook(workbookPath, false);

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved successfully to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}