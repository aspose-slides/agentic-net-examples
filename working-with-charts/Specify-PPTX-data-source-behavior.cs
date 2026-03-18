using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for input (if any) and output files
            string outputPath = "DataSourceBehavior.pptx";

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Add a pie chart to the slide
                IChart chart = slide.Shapes.AddChart(
                    ChartType.Pie,    // Fully qualified enum value
                    50f, 50f, 400f, 400f);

                // Set an external workbook as the data source for the chart
                // Cast ChartData to its concrete type to access SetExternalWorkbook method
                ChartData chartData = chart.ChartData as ChartData;
                if (chartData != null)
                {
                    chartData.SetExternalWorkbook("externalData.xlsx");
                }

                // Retrieve the data source type (read‑only property) to verify the setting
                ChartDataSourceType sourceType = chartData.DataSourceType;
                Console.WriteLine("Chart data source type: " + sourceType);

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during processing
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}