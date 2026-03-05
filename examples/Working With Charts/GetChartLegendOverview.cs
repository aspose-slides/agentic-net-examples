using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a clustered column chart with sample data
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

        // Validate layout to calculate actual legend dimensions
        chart.ValidateChartLayout();

        // Ensure the legend is visible
        chart.HasLegend = true;

        // Access the legend object
        Aspose.Slides.Charts.Legend legend = (Aspose.Slides.Charts.Legend)chart.Legend;

        // Set custom position and size for the legend (fractions of chart size)
        legend.X = 0.8f;      // 80% from the left edge of the chart
        legend.Y = 0.1f;      // 10% from the top edge of the chart
        legend.Width = 0.15f; // 15% of the chart width
        legend.Height = 0.3f; // 30% of the chart height

        // Prevent other chart elements from overlapping the legend
        legend.Overlay = false;

        // Save the presentation
        pres.Save("ChartLegendOverview.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}