using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExternalWorkbookIntegration
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define directories and file paths
            string dataDir = "Data";
            Directory.CreateDirectory(dataDir);
            string workbookPath = Path.Combine(dataDir, "workbook.xlsx");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Ensure the external workbook exists
            if (!File.Exists(workbookPath))
            {
                // Create an empty workbook file as a placeholder
                File.WriteAllBytes(workbookPath, new byte[0]);
            }

            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a pie chart to the first slide
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Pie, 50, 50, 400, 600, true);

            // Link the chart to the external workbook and update chart data
            Aspose.Slides.Charts.IChartData chartData = chart.ChartData;
            ((Aspose.Slides.Charts.ChartData)chartData).SetExternalWorkbook(workbookPath, true);

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();
        }
    }
}