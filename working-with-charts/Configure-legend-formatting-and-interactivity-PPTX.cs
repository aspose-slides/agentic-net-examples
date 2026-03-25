using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a clustered column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 500f, 400f);

        // Validate layout to ensure actual values are calculated
        chart.ValidateChartLayout();

        // Access the legend
        Aspose.Slides.Charts.ILegend legend = chart.Legend;

        // Customize legend appearance
        legend.Position = Aspose.Slides.Charts.LegendPositionType.Right;
        legend.X = 0.8f;      // Position as fraction of chart width
        legend.Y = 0.1f;      // Position as fraction of chart height
        legend.Width = 0.15f; // Width as fraction of chart width
        legend.Height = 0.3f; // Height as fraction of chart height
        legend.Overlay = false;

        // Set legend font size
        legend.TextFormat.PortionFormat.FontHeight = 14f;

        // Ensure legend is displayed
        chart.HasLegend = true;

        // Save the presentation
        pres.Save("CustomizedLegend.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}