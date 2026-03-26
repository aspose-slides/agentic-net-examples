using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart with specified position and size
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

        // Adjust legend placement using custom coordinates (fraction of chart dimensions)
        chart.Legend.X = 0.1f;      // 10% from the left edge of the chart
        chart.Legend.Y = 0.9f;      // 90% from the top edge of the chart
        chart.Legend.Width = 0.2f;  // Legend occupies 20% of the chart width
        chart.Legend.Height = 0.1f; // Legend occupies 10% of the chart height

        // Save the modified presentation
        presentation.Save("LegendPlacement.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}