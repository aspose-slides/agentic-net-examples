using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a line chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Line, 50, 50, 500, 400);

        // Access the first series of the chart
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

        // Set marker size and style
        series.Marker.Size = 12;
        series.Marker.Symbol = Aspose.Slides.Charts.MarkerStyleType.Diamond;

        // Save the presentation
        presentation.Save("MarkerStyleSize.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}