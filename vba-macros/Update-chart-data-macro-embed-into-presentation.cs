// -----------------------------------------------------------------------------
// Example: Add chart with external workbook data source using C#
//
// Description:
// Demonstrates how to load an existing PowerPoint presentation, add a chart,
// and link it to an external Excel workbook as its data source using
// Aspose.Slides for .NET. The example shows loading, chart creation, setting
// external workbook, and saving the updated presentation. This pattern can be
// used to automate chart data updates in PPTX files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, External Workbook,
// Data Source, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding charts linked to external Excel data in PowerPoint files.
// - Build tools for updating presentation data from spreadsheets.
// - Generate or modify PPTX files programmatically in .NET applications.
// - Integrate chart data updates into CI pipelines.
// -----------------------------------------------------------------------------

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
