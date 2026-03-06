using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SpecifyDataSourceTypeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Create a new presentation (or load an existing one)
            Presentation pres = new Presentation();

            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a pie chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.Pie, 0, 0, 500, 400) as IChart;

            // OPTIONAL: Set an external workbook as the data source
            // ((ChartData)chart.ChartData).SetExternalWorkbook("data.xlsx");

            // Retrieve the data source type of the chart
            ChartDataSourceType sourceType = chart.ChartData.DataSourceType;

            // If the chart uses an external workbook, get its path
            if (sourceType == ChartDataSourceType.ExternalWorkbook)
            {
                string externalPath = chart.ChartData.ExternalWorkbookPath;
                // Use externalPath as needed (e.g., logging)
                Console.WriteLine("External workbook path: " + externalPath);
            }

            // Save the presentation before exiting
            pres.Save(outputPath, SaveFormat.Pptx);

            // Clean up resources
            pres.Dispose();
        }
    }
}