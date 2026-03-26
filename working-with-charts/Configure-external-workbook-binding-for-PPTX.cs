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
        string presentationPath = Path.Combine(dataDir, "output.pptx");
        string workbookPath = Path.Combine(dataDir, "data.xlsx");

        // Ensure the data directory exists
        if (!Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
        }

        // Ensure the external workbook file exists (create an empty placeholder if missing)
        if (!File.Exists(workbookPath))
        {
            File.WriteAllBytes(workbookPath, new byte[0]);
        }

        // Create a new presentation
        Presentation presentation = new Presentation();

        // Add a pie chart to the first slide
        IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);

        // Get the chart data object
        IChartData chartData = chart.ChartData;

        // Set the external workbook as data source without loading chart data immediately
        ((ChartData)chartData).SetExternalWorkbook(workbookPath, false);

        // Save the presentation
        presentation.Save(presentationPath, SaveFormat.Pptx);
    }
}