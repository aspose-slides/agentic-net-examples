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

        // Add a clustered column chart with sample dimensions
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f,   // X position
            50f,   // Y position
            500f,  // Width
            400f   // Height
        );

        // Adjust legend placement using custom coordinates (fractions of chart size)
        chart.Legend.X = 0.1f;      // 10% from the left edge of the chart
        chart.Legend.Y = 0.9f;      // 90% from the top edge of the chart
        chart.Legend.Width = 0.3f;  // Legend occupies 30% of the chart width
        chart.Legend.Height = 0.2f; // Legend occupies 20% of the chart height

        // Save the modified presentation
        presentation.Save("AdjustedLegend.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}