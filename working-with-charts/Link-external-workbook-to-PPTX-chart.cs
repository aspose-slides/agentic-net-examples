using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define directories and file paths
        string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        Directory.CreateDirectory(dataDir);
        string workbookPath = Path.Combine(dataDir, "workbook.xlsx");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        // Ensure the external workbook exists
        if (!File.Exists(workbookPath))
        {
            File.WriteAllBytes(workbookPath, new byte[0]);
        }

        // Create a new presentation
        Presentation presentation = new Presentation();

        // Add a chart to the first slide
        IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);

        // Link the external workbook without embedding it
        IChartData chartData = chart.ChartData;
        ((ChartData)chartData).SetExternalWorkbook(workbookPath, false);

        // Save the presentation
        presentation.Save(outputPath, SaveFormat.Pptx);
    }
}