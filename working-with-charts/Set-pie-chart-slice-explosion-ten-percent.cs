using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a pie chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Pie,
            50,   // X position
            50,   // Y position
            400,  // Width
            400   // Height
        );

        // Set explosion (slice distance) to 10% for highlighted data points
        // Assuming the chart has at least two data points
        chart.ChartData.Series[0].DataPoints[0].Explosion = 10;
        chart.ChartData.Series[0].DataPoints[1].Explosion = 10;

        // Save the presentation
        pres.Save("PieChartExplosion.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}