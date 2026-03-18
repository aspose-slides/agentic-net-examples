using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Add a chart to the first slide
            Aspose.Slides.Charts.IChart chart = pres.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50f, 50f, 400f, 300f);

            // Define a custom data range for the chart
            chart.ChartData.SetRange("Sheet1!$A$1:$C$4");

            // Retrieve and display the current data range
            string range = chart.ChartData.GetRange();
            Console.WriteLine("Chart data range: " + range);

            // Save the presentation
            pres.Save("CustomRangeChart.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}