using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        var slide = presentation.Slides[0];

        // Add a clustered column chart
        var chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 0, 0, 500, 400);

        // Get the first series of the chart
        var series = chart.ChartData.Series[0];

        // Set the series fill type to solid
        series.Format.Fill.FillType = Aspose.Slides.FillType.Solid;

        // Configure the inverted solid fill color for the series
        series.InvertedSolidFillColor.Color = System.Drawing.Color.Yellow;

        // Save the presentation
        presentation.Save("InvertedFillChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}