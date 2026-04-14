using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for the output presentation and the source workbook
            string outputPath = "ChartWithNamedRange.pptx";
            string workbookPath = "DataWorkbook.xlsx";

            // Verify that the workbook file exists
            if (!File.Exists(workbookPath))
            {
                Console.WriteLine("Workbook file not found: " + workbookPath);
                return;
            }

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add a chart to the first slide
                IChart chart = presentation.Slides[0].Shapes.AddChart(
                    ChartType.Pie, 50f, 50f, 400f, 600f, true);

                // Set the external workbook as the data source (do not update chart data yet)
                chart.ChartData.SetExternalWorkbook(workbookPath, false);

                // Define the data range using a named range in the workbook
                // Example named range: "MyNamedRange" defined on Sheet1
                chart.ChartData.SetRange("Sheet1!MyNamedRange");

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Handle unsupported file format here
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}