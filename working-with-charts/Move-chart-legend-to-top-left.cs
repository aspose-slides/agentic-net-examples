using System;
using Aspose.Slides;
using Aspose.Slides.Export;

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
            50f,   // X position
            50f,   // Y position
            500f,  // Width
            400f   // Height
        );

        // Move the legend to the top left corner using custom coordinates
        chart.Legend.X = 0f;                     // X as fraction of chart width
        chart.Legend.Y = 0f;                     // Y as fraction of chart height
        chart.Legend.Width = 0.2f;               // Width as fraction of chart width
        chart.Legend.Height = 0.2f;              // Height as fraction of chart height
        chart.Legend.Position = Aspose.Slides.Charts.LegendPositionType.Top; // Optional enum position

        // Save the presentation
        try
        {
            presentation.Save("LegendTopLeft.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle cases where the format is not supported
            // Format not supported: ex.Message
        }
    }
}