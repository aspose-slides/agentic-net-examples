using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation pres = new Presentation();

        // Access the first slide
        ISlide slide = pres.Slides[0];

        // Add a clustered column chart
        IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

        // Ensure the chart has a legend
        chart.HasLegend = true;

        // Position the legend at the top right corner
        chart.Legend.Position = LegendPositionType.TopRight;

        // Save the presentation
        try
        {
            pres.Save("ChartLegendTopRight.pptx", SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Handle format not supported or other errors
        }
    }
}