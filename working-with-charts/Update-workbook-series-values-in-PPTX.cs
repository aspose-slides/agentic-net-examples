using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for the external workbook and output presentation
        string dataDir = "Data";
        string workbookPath = Path.Combine(dataDir, "chartData.xlsx");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        // Verify that the external workbook exists
        if (!File.Exists(workbookPath))
        {
            Console.WriteLine("Workbook not found: " + workbookPath);
            return;
        }

        // Create a new presentation
        Presentation presentation = new Presentation();

        // Add a pie chart with sample data
        IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);

        // Set the external workbook without updating chart data initially
        IChartData chartData = chart.ChartData;
        ((ChartData)chartData).SetExternalWorkbook(workbookPath, false);

        // Update chart data from the external workbook
        ((ChartData)chartData).SetExternalWorkbook(workbookPath, true);

        // Modify a data point value in the first series
        if (chart != null && chart.ChartData.Series.Count > 0 && chart.ChartData.Series[0].DataPoints.Count > 0)
        {
            chart.ChartData.Series[0].DataPoints[0].Value.Data = 75;
        }

        // Save the presentation
        presentation.Save(outputPath, SaveFormat.Pptx);
    }
}