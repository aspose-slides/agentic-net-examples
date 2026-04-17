using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define paths
        string dataDir = Directory.GetCurrentDirectory();
        string inputPath = Path.Combine(dataDir, "input.pptx");
        string outputPath = Path.Combine(dataDir, "output.pptx");
        string workbookPath = Path.Combine(dataDir, "data.xlsx");

        // Check if input presentation exists
        if (!File.Exists(inputPath))
        {
            // Input file does not exist
            return;
        }

        // Load the existing presentation
        Aspose.Slides.Presentation presentation = null;
        try
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception)
        {
            // Handle unsupported file format
            return;
        }

        // Add a chart and set external workbook as data source
        try
        {
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Pie, 50f, 50f, 400f, 600f, true);
            Aspose.Slides.Charts.IChartData chartData = chart.ChartData;
            ((Aspose.Slides.Charts.ChartData)chartData).SetExternalWorkbook(workbookPath, true);
        }
        catch (InvalidOperationException)
        {
            // External workbook not available or cannot be loaded
        }

        // Save the updated presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}