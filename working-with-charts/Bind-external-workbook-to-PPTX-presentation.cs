using System;
using System.IO;
using Aspose.Slides.Export;

namespace ExternalWorkbookDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define data directory and ensure it exists
            string dataDir = "Data";
            Directory.CreateDirectory(dataDir);

            // Define workbook and output file paths
            string workbookPath = Path.Combine(dataDir, "workbook.xlsx");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Create a dummy workbook file if it does not exist
            if (!File.Exists(workbookPath))
            {
                File.WriteAllBytes(workbookPath, new byte[0]);
            }

            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Add a pie chart to the first slide
            Aspose.Slides.Charts.IChart chart = pres.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Pie, 50, 50, 400, 600, true);

            // Get chart data
            Aspose.Slides.Charts.IChartData chartData = chart.ChartData;

            // Associate the external workbook with the chart (updates chart data)
            ((Aspose.Slides.Charts.ChartData)chartData).SetExternalWorkbook(workbookPath);

            // Save the presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}