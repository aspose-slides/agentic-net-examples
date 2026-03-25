using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AddExternalWorkbookExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for the presentation and the external Excel workbook
            string presentationPath = "InputPresentation.pptx";
            string workbookPath = "DataWorkbook.xlsx";
            string outputPath = "OutputPresentation.pptx";

            // Verify that the input files exist
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Error: Presentation file not found: " + presentationPath);
                return;
            }

            if (!File.Exists(workbookPath))
            {
                Console.WriteLine("Error: Workbook file not found: " + workbookPath);
                return;
            }

            try
            {
                // Load the existing presentation
                using (Presentation pres = new Presentation(presentationPath))
                {
                    // Access the first slide
                    ISlide slide = pres.Slides[0];

                    // Add a new chart to the slide
                    IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 300, true);

                    // Set the external workbook as the data source for the chart
                    IChartData chartData = chart.ChartData;
                    ((ChartData)chartData).SetExternalWorkbook(workbookPath, false);

                    // Save the modified presentation
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }

                Console.WriteLine("Presentation saved successfully to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}