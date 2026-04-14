using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a pie chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 50, 50, 400, 400);

        // Access the first series
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

        // Set explosion for the first data point to 10%
        series.DataPoints[0].Explosion = 10;

        // Save the presentation
        pres.Save("PieChartExplosion.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}