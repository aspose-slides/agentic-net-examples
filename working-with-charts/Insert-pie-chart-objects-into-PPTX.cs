using System;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Access the first slide (index 0)
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a pie chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Pie,
                50f,   // X position
                50f,   // Y position
                400f,  // Width
                400f   // Height
            );

            // Access the first series of the chart
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

            // Set the explosion (slice offset) for the first data point
            series.DataPoints[0].Explosion = 20; // 20% of the pie diameter

            // Save the presentation
            pres.Save("PieChartCustomSlice.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}