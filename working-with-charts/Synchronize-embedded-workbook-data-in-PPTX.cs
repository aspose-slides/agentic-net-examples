using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace UpdateWorkbookInPresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define paths
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string inputPptx = Path.Combine(dataDir, "input.pptx");
            string workbookPath = Path.Combine(dataDir, "workbook.xlsx");
            string outputPptx = Path.Combine(dataDir, "output.pptx");

            // Verify input files exist
            if (!File.Exists(inputPptx))
            {
                Console.WriteLine("Input presentation file not found: " + inputPptx);
                return;
            }

            if (!File.Exists(workbookPath))
            {
                Console.WriteLine("Workbook file not found: " + workbookPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPptx))
                {
                    // Retrieve the first chart on the first slide
                    IChart chart = pres.Slides[0].Shapes[0] as IChart;
                    if (chart == null)
                    {
                        Console.WriteLine("No chart found on the first slide.");
                        return;
                    }

                    // Set external workbook as data source (do not update chart data automatically)
                    ((ChartData)chart.ChartData).SetExternalWorkbook(workbookPath, false);

                    // Example: update a data point in the first series
                    if (chart.ChartData.Series.Count > 0 && chart.ChartData.Series[0].DataPoints.Count > 0)
                    {
                        chart.ChartData.Series[0].DataPoints[0].Value.Data = 123.45;
                    }

                    // Save the updated presentation
                    pres.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx);
                }

                Console.WriteLine("Presentation saved successfully to: " + outputPptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}