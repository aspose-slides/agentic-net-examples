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
            // Define input and output file paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Cast the first shape to a chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes[0] as Aspose.Slides.Charts.IChart;

            if (chart != null)
            {
                // Get the embedded workbook associated with the chart
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Iterate through worksheets and print their names
                foreach (Aspose.Slides.Charts.IChartDataWorksheet worksheet in workbook.Worksheets)
                {
                    Console.WriteLine("Worksheet Name: " + worksheet.Name);
                }
            }
            else
            {
                Console.WriteLine("No chart found on the first slide.");
            }

            // Save the presentation before exiting
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            pres.Dispose();
        }
    }
}