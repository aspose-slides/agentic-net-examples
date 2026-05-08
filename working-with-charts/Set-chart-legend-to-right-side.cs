using System;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
        {
            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a clustered column chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

            // Ensure the chart has a legend
            chart.HasLegend = true;

            // Position the legend on the right side of the chart
            chart.Legend.Position = LegendPositionType.Right;

            // Save the presentation to disk
            pres.Save("ChartLegendRight.pptx", SaveFormat.Pptx);
        }
    }
}