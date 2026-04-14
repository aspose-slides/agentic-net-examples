using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50f, 50f, 500f, 400f);

            // Set legend position to bottom‑right using custom coordinates
            chart.Legend.X = 0.7f;      // X position as fraction of chart width
            chart.Legend.Y = 0.9f;      // Y position as fraction of chart height
            chart.Legend.Width = 0.2f;  // Width as fraction of chart width
            chart.Legend.Height = 0.1f; // Height as fraction of chart height

            // Save the presentation
            presentation.Save("LegendBottomRight.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.NotSupportedException)
        {
            // Format not supported
        }
        catch (System.Exception)
        {
            // Handle other exceptions (e.g., file I/O, licensing)
        }
    }
}