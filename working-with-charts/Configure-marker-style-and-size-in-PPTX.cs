using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation pres = new Presentation();
        // Access the first slide
        ISlide slide = pres.Slides[0];
        // Add a line chart with markers
        IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 0f, 0f, 500f, 400f);
        // Set marker size and style for the first series
        chart.ChartData.Series[0].Marker.Size = 10;
        chart.ChartData.Series[0].Marker.Symbol = MarkerStyleType.Circle;
        // Save the presentation
        pres.Save("MarkerStyleChart.pptx", SaveFormat.Pptx);
    }
}