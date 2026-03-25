using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

        // Customize legend position and size
        chart.Legend.X = 0.8f; // 80% of chart width
        chart.Legend.Y = 0.1f; // 10% of chart height
        chart.Legend.Width = 0.15f; // 15% of chart width
        chart.Legend.Height = 0.3f; // 30% of chart height

        // Set legend position type
        chart.Legend.Position = Aspose.Slides.Charts.LegendPositionType.Right;

        // Save the presentation
        presentation.Save("CustomLegendChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}