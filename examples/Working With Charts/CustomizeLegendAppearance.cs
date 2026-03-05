using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            0f, 0f, 500f, 400f);

        // Customize legend position and size
        chart.Legend.X = 0.5f; // X coordinate as fraction of chart width
        chart.Legend.Y = 0.5f; // Y coordinate as fraction of chart height
        chart.Legend.Width = 0.3f; // Width as fraction of chart width
        chart.Legend.Height = 0.2f; // Height as fraction of chart height

        // Additional legend appearance settings
        chart.Legend.Position = Aspose.Slides.Charts.LegendPositionType.Right;
        chart.Legend.Overlay = false;

        // Save the presentation
        presentation.Save("CustomLegend.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}