using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create data directory
        string dataDir = "Data";
        Directory.CreateDirectory(dataDir);

        // Define external workbook path
        string workbookPath = Path.Combine(dataDir, "workbook.xlsx");

        // Ensure the workbook file exists (create an empty file if necessary)
        if (!File.Exists(workbookPath))
        {
            File.WriteAllBytes(workbookPath, new byte[0]);
        }

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a pie chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Pie, 50, 50, 400, 600);

        // Get the chart data object
        Aspose.Slides.Charts.IChartData chartData = chart.ChartData;

        // Set the external workbook as the data source for the chart
        ((Aspose.Slides.Charts.ChartData)chartData).SetExternalWorkbook(workbookPath);

        // Save the presentation
        string outputPath = Path.Combine(dataDir, "ExternalWorkbookDemo.pptx");
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}