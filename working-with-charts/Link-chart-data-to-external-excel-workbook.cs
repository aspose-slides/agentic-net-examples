// -----------------------------------------------------------------------------
// Example: Link chart data to external excel workbook using C#
//
// Description:
// Demonstrates how to link a chart's data to an external Excel workbook using
// C# and Aspose.Slides for .NET. The example loads an existing presentation,
// associates the first chart on the first slide with a specified workbook,
// enables dynamic updates, and saves the modified presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Link, Chart, Data, External, Excel,
// Workbook, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate linking chart data to an external Excel workbook.
// - Build C# tools for PowerPoint presentation processing with external data sources.
// - Generate or transform PPTX files that reference external Excel data in .NET applications.
// - Validate and maintain chart data synchronization before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Define paths
        string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        string inputPath = Path.Combine(dataDir, "input.pptx");
        string outputPath = Path.Combine(dataDir, "output.pptx");
        string workbookPath = Path.Combine(dataDir, "data.xlsx");

        // Verify input files exist
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input presentation not found: " + inputPath);
            return;
        }

        if (!File.Exists(workbookPath))
        {
            Console.WriteLine("Workbook not found: " + workbookPath);
            return;
        }

        try
        {
            // Load presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Assume the first shape on the first slide is a chart
                IChart chart = presentation.Slides[0].Shapes[0] as IChart;
                if (chart != null)
                {
                    // Link chart to external workbook and enable dynamic updates
                    IChartData chartData = chart.ChartData;
                    ((ChartData)chartData).SetExternalWorkbook(workbookPath, true);
                }
                else
                {
                    Console.WriteLine("No chart found on the first slide.");
                }

                // Save the updated presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (InvalidOperationException ex)
        {
            // Handle errors related to external workbook loading
            Console.WriteLine("Error linking external workbook: " + ex.Message);
        }
        catch (Exception ex)
        {
            // Handle other possible errors (e.g., unsupported format)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
