using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define file paths
        string dataDir = "Data";
        string inputPptx = Path.Combine(dataDir, "input.pptx");
        string workbookPath = Path.Combine(dataDir, "data.xlsx");
        string outputPptx = Path.Combine(dataDir, "output.pptx");

        // Verify input files exist
        if (!File.Exists(inputPptx))
        {
            Console.WriteLine("Input PPTX file not found: " + inputPptx);
            return;
        }
        if (!File.Exists(workbookPath))
        {
            Console.WriteLine("Workbook file not found: " + workbookPath);
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPptx);

        // Add a pie chart with sample data
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Pie, 50, 50, 400, 600, true);

        // Access chart data
        Aspose.Slides.Charts.IChartData chartData = chart.ChartData;

        // Set external workbook and update chart data
        ((Aspose.Slides.Charts.ChartData)chartData).SetExternalWorkbook(workbookPath, true);

        // Save the updated presentation
        presentation.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}