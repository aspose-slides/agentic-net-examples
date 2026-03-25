using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

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

        // Adjust legend position and size (fraction of chart dimensions)
        chart.Legend.X = 0.7f;      // 70% from the left edge of the chart
        chart.Legend.Y = 0.1f;      // 10% from the top edge of the chart
        chart.Legend.Width = 0.2f;  // 20% of the chart width
        chart.Legend.Height = 0.2f; // 20% of the chart height

        // Save the presentation
        try
        {
            presentation.Save("AdjustedLegend.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
    }
}