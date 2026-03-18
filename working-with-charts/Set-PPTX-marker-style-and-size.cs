using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.LineWithMarkers,
                0,
                0,
                500,
                400);

            // Configure marker style and size for the first series
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];
            series.Marker.Symbol = Aspose.Slides.Charts.MarkerStyleType.Diamond;
            series.Marker.Size = 12;

            // Save the presentation
            presentation.Save("MarkerChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}