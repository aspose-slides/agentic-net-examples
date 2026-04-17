using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define paths
        var dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        var inputPath = Path.Combine(dataDir, "input.pptx");
        var workbookPath = Path.Combine(dataDir, "data.xlsx");
        var outputPath = Path.Combine(dataDir, "output.pptx");

        // Verify input presentation exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input presentation not found.");
            return;
        }

        // Load presentation
        Presentation pres;
        try
        {
            pres = new Presentation(inputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        // Get the first chart on the first slide
        var chart = pres.Slides[0].Shapes[0] as IChart;
        if (chart == null)
        {
            Console.WriteLine("No chart found in the presentation.");
            // Save unchanged presentation
            pres.Save(outputPath, SaveFormat.Pptx);
            return;
        }

        var chartData = chart.ChartData;

        // Link external workbook for dynamic updates
        try
        {
            ((ChartData)chartData).SetExternalWorkbook(workbookPath, true);
        }
        catch (InvalidOperationException)
        {
            // Workbook not available; link without updating data
            ((ChartData)chartData).SetExternalWorkbook(workbookPath, false);
        }
        catch (NotSupportedException)
        {
            // Format not supported
            // Comment: The workbook format is not supported.
        }

        // Save the updated presentation
        pres.Save(outputPath, SaveFormat.Pptx);
    }
}