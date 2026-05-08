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