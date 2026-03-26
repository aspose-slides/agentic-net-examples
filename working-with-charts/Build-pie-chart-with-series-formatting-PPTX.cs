using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a pie chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 50, 50, 400, 300);

        // Get the first series of the chart
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

        // Customize slice explosion values
        series.DataPoints[0].Explosion = 20;
        series.DataPoints[1].Explosion = 0;
        series.DataPoints[2].Explosion = 10;

        // Show values in data labels
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

        // Save the presentation
        presentation.Save("PieChartPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}