using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output path
            string dataDir = Directory.GetCurrentDirectory();
            string outputPath = Path.Combine(dataDir, "EmbeddedWorkbookExample.pptx");

            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a bubble chart to the first slide
            IChart chart = (IChart)presentation.Slides[0].Shapes.AddChart(
                ChartType.Bubble, 50f, 50f, 600f, 400f, true);

            // Access the embedded workbook of the chart
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Iterate through worksheets in the embedded workbook
            foreach (IChartDataWorksheet worksheet in workbook.Worksheets)
            {
                // Output worksheet name to console
                Console.WriteLine("Worksheet Name: " + worksheet.Name);
            }

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}