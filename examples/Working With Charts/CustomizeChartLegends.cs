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

        // Customize legend position and size (fractions of the chart dimensions)
        chart.Legend.X = 0.8f;
        chart.Legend.Y = 0.1f;
        chart.Legend.Width = 0.2f;
        chart.Legend.Height = 0.2f;

        // Set legend font size
        chart.Legend.TextFormat.PortionFormat.FontHeight = 14f;

        // Ensure the legend is visible
        chart.HasLegend = true;

        // Save the presentation
        pres.Save("CustomizedLegend.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}