using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50, 50, 500, 400);

            // Ensure the chart displays a legend
            chart.HasLegend = true;

            // Position the legend at the bottom of the chart
            chart.Legend.Position = Aspose.Slides.Charts.LegendPositionType.Bottom;

            // Set overlay to false for a horizontal layout (legend below the chart)
            chart.Legend.Overlay = false;

            // Save the presentation to a file
            presentation.Save("ChartLegendBottomHorizontal.pptx", SaveFormat.Pptx);
        }
    }
}