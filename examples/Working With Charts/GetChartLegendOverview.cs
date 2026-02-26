using System;

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

            // Position the legend to the right side of the chart
            chart.Legend.Position = Aspose.Slides.Charts.LegendPositionType.Right;

            // Allow other chart elements to overlap the legend
            chart.Legend.Overlay = true;

            // Adjust legend size (relative to chart dimensions)
            chart.Legend.Width = 0.2f;   // 20% of chart width
            chart.Legend.Height = 0.5f;  // 50% of chart height

            // Save the presentation
            presentation.Save("ChartLegendOverview.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}