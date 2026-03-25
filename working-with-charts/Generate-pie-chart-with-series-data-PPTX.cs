using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a pie chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Pie, 50f, 50f, 400f, 400f);

        // Get the first series of the chart
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

        // Configure a slice to be exploded (pulled out) by 20%
        series.DataPoints[0].Explosion = 20;

        // Save the presentation to a PPTX file
        presentation.Save("PieChartOutput.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}