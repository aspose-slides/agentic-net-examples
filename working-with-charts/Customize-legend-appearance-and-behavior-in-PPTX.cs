using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

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

        // Validate layout to get actual values
        chart.ValidateChartLayout();

        // Set chart title
        chart.HasTitle = true;
        chart.ChartTitle.AddTextFrameForOverriding("Sales Overview");
        chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;

        // Ensure legend is visible
        chart.HasLegend = true;

        // Customize legend appearance
        chart.Legend.Position = Aspose.Slides.Charts.LegendPositionType.Right;
        chart.Legend.X = 0.8f;      // Position as fraction of chart width
        chart.Legend.Y = 0.1f;      // Position as fraction of chart height
        chart.Legend.Width = 0.15f; // Width as fraction of chart width
        chart.Legend.Height = 0.8f; // Height as fraction of chart height
        chart.Legend.Overlay = false;

        // Set legend font size
        chart.Legend.TextFormat.PortionFormat.FontHeight = 14f;

        // Save the presentation
        pres.Save("CustomizedLegend.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}