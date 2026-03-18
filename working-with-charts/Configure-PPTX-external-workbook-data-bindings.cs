using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Add a pie chart to the first slide
                IChart chart = pres.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 50, 50, 400, 600, true);
                
                // Access the chart data
                IChartData chartData = chart.ChartData;
                
                // Set an external workbook as the data source for the chart
                ((Aspose.Slides.Charts.ChartData)chartData).SetExternalWorkbook("externalData.xlsx");
                
                // Save the presentation
                pres.Save("ExternalWorkbookChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}