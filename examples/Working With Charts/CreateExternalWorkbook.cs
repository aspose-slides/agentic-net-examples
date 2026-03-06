using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        using (Presentation pres = new Presentation())
        {
            // Add a pie chart to the first slide
            IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);

            // Get the chart data object
            IChartData chartData = chart.ChartData;

            // Set an external Excel workbook as the data source for the chart
            ((ChartData)chartData).SetExternalWorkbook("workbook.xlsx");

            // Save the presentation
            pres.Save("ExternalWorkbookChart_out.pptx", SaveFormat.Pptx);
        }
    }
}