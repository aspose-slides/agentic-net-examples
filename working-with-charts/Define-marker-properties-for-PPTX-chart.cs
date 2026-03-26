using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Presentation presentation = new Presentation())
        {
            // Add a line chart to the first slide
            IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 50, 50, 500, 400);

            // Get the first series of the chart
            IChartSeries series = chart.ChartData.Series[0];

            // Set marker properties for the first data point
            IMarker marker1 = series.DataPoints[0].Marker;
            marker1.Size = 12;
            marker1.Symbol = MarkerStyleType.Circle;

            // Set marker properties for the second data point
            IMarker marker2 = series.DataPoints[1].Marker;
            marker2.Size = 12;
            marker2.Symbol = MarkerStyleType.Square;

            // Save the presentation
            presentation.Save("ChartMarkerProperties_out.pptx", SaveFormat.Pptx);
        }
    }
}