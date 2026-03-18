using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Presentation();
            var slide = presentation.Slides[0];

            // Add a line chart to the slide
            var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 500, 400, true);

            // Access the first series of the chart
            var series = chart.ChartData.Series[0];

            // Configure marker properties
            var marker = series.Marker;
            marker.Size = 12;
            marker.Symbol = MarkerStyleType.Circle;

            // Set marker fill color
            marker.Format.Fill.FillType = FillType.Solid;
            marker.Format.Fill.SolidFillColor.SchemeColor = SchemeColor.Accent1;

            // Set marker border (line) color
            marker.Format.Line.FillFormat.FillType = FillType.Solid;
            marker.Format.Line.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent2;

            // Save the presentation
            presentation.Save("MarkersDemo.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}