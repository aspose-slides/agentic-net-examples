using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RetrieveEmbeddedWorkbook
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Configure load options to recover workbook from chart cache
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
            loadOptions.SpreadsheetOptions.RecoverWorkbookFromChartCache = true;

            // Load the presentation with the specified options
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath, loadOptions))
            {
                // Access the first chart on the first slide
                Aspose.Slides.Charts.IChart chart = pres.Slides[0].Shapes[0] as Aspose.Slides.Charts.IChart;
                if (chart != null)
                {
                    // Retrieve the embedded workbook associated with the chart
                    Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                    // Example: read a cell value (optional, demonstrates access)
                    // Aspose.Slides.Charts.IChartDataCell cell = workbook.GetCell(0, "A1");
                    // Console.WriteLine("Cell A1 value: " + cell.Value);
                }

                // Save the presentation after processing
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }

            Console.WriteLine("Presentation processed and saved to: " + outputPath);
        }
    }
}