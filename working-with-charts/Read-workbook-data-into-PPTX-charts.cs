using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Import;
using Aspose.Slides.Export;

namespace ChartFromWorkbookExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input workbook and output presentation paths
            string inputWorkbookPath = "data.xlsx";
            string outputPresentationPath = "output.pptx";

            // Verify that the input workbook exists
            if (!File.Exists(inputWorkbookPath))
            {
                Console.WriteLine("Error: Input workbook file not found: " + inputWorkbookPath);
                return;
            }

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add a chart from the workbook to the first slide
                // Parameters: shape collection, X, Y, workbook path, worksheet name, chart name, embedWorkbook flag
                IChart chart = ExcelWorkbookImporter.AddChartFromWorkbook(
                    presentation.Slides[0].Shapes,
                    50f,
                    50f,
                    inputWorkbookPath,
                    "Sheet1",
                    "Chart 1",
                    false);

                // Optionally, you can manipulate the chart or its data here

                // Save the presentation
                presentation.Save(outputPresentationPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved successfully to: " + outputPresentationPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}