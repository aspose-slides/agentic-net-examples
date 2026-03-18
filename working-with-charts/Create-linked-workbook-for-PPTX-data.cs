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
            try
            {
                // Path to the external Excel workbook
                string workbookPath = "data.xlsx";

                // Create a new presentation
                using (Presentation pres = new Presentation())
                {
                    // Access the first slide
                    ISlide slide = pres.Slides[0];

                    // Add a chart to the slide
                    IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50f, 50f, 400f, 300f);

                    // Set the external workbook as the data source for the chart
                    ChartData chartData = (ChartData)chart.ChartData;
                    chartData.SetExternalWorkbook(workbookPath);

                    // Save the presentation
                    pres.Save("LinkedWorkbookPresentation.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}