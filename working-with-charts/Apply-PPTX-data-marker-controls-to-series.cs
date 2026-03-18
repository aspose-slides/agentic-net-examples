using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var pres = new Aspose.Slides.Presentation();
            var slide = pres.Slides[0];
            var chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ScatterWithMarkers, 50, 50, 500, 400);
            var series = chart.ChartData.Series[0];
            series.Marker.Symbol = Aspose.Slides.Charts.MarkerStyleType.Diamond;
            series.Marker.Size = 12;
            if (chart.ChartData.Series.Count > 1)
            {
                var series2 = chart.ChartData.Series[1];
                series2.Marker.Symbol = Aspose.Slides.Charts.MarkerStyleType.Triangle;
                series2.Marker.Size = 10;
            }
            pres.Save("ChartMarkerDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}