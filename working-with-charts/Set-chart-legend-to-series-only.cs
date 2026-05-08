using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (Presentation pres = new Presentation())
            {
                ISlide slide = pres.Slides[0];
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
                // Ensure legend is displayed
                chart.HasLegend = true;
                // Position legend to the right (shows only series names by default)
                chart.Legend.Position = LegendPositionType.Right;
                // Save the presentation before exiting
                pres.Save("ChartLegendSeriesOnly.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unexpected errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}