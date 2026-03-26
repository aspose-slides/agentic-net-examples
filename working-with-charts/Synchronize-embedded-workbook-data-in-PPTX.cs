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
            // Define file paths
            string inputPptxPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string externalWorkbookPath = Path.Combine(Directory.GetCurrentDirectory(), "data.xlsx");
            string outputPptxPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

            // Verify input presentation exists
            if (!File.Exists(inputPptxPath))
            {
                Console.WriteLine("Input presentation not found: " + inputPptxPath);
                return;
            }

            // Verify external workbook exists
            if (!File.Exists(externalWorkbookPath))
            {
                Console.WriteLine("External workbook not found: " + externalWorkbookPath);
                return;
            }

            // Load the presentation
            Presentation pres = new Presentation(inputPptxPath);

            // Get the first chart on the first slide
            IChart chart = pres.Slides[0].Shapes[0] as IChart;
            if (chart == null)
            {
                Console.WriteLine("No chart found on the first slide.");
                pres.Dispose();
                return;
            }

            // Set external workbook without updating chart data immediately
            ((ChartData)chart.ChartData).SetExternalWorkbook(externalWorkbookPath, false);

            // Update a data point in the chart (synchronizing with workbook)
            chart.ChartData.Series[0].DataPoints[0].Value.Data = 42;

            // Save the updated presentation
            pres.Save(outputPptxPath, SaveFormat.Pptx);

            // Clean up
            pres.Dispose();

            Console.WriteLine("Presentation saved to: " + outputPptxPath);
        }
    }
}