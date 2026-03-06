using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a clustered column chart with sample data
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 0, 0, 500, 400);

        // Get the first series (sample series is already added)
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

        // Set the series fill type to solid (required before setting color)
        series.Format.Fill.FillType = Aspose.Slides.FillType.Solid;

        // Set the inverted solid fill color for the series
        series.InvertedSolidFillColor.Color = Color.Blue;

        // Save the presentation
        presentation.Save("InvertFillColorChartSeries.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}