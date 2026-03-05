using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        var slide = presentation.Slides[0];

        // Add a chart to the slide
        var chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

        // Access the plot area of the chart
        var plotArea = chart.PlotArea;

        // Set solid fill for the plot area
        plotArea.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        plotArea.Format.Fill.SolidFillColor.Color = Color.LightGray;

        // Set border (line) for the plot area
        plotArea.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        plotArea.Format.Line.FillFormat.SolidFillColor.Color = Color.Black;
        plotArea.Format.Line.Width = 2;

        // Save the presentation
        presentation.Save("PlotAreaFormatting_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}