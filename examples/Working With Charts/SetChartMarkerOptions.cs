class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a line chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Line, 50, 50, 500, 400);

        // Access the first series of the chart
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

        // Set marker size and style for the series
        series.Marker.Size = 10;
        series.Marker.Symbol = Aspose.Slides.Charts.MarkerStyleType.Circle;

        // Optionally set marker for the first data point
        Aspose.Slides.Charts.IChartDataPoint point = series.DataPoints[0];
        point.Marker.Size = 12;
        point.Marker.Symbol = Aspose.Slides.Charts.MarkerStyleType.Square;

        // Save the presentation
        presentation.Save("ChartMarkerOptions_out.pptx",
            Aspose.Slides.Export.SaveFormat.Pptx);
    }
}