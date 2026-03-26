using System;
using System.Drawing;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            20, 100, 600, 400);

        // Configure the plot area's fill color
        chart.PlotArea.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightGray;

        // Configure the plot area's border (line) color and width
        chart.PlotArea.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        chart.PlotArea.Format.Line.FillFormat.SolidFillColor.Color = Color.Black;
        chart.PlotArea.Format.Line.Width = 2;

        // Save the presentation to disk
        presentation.Save("SetPlotAreaFillAndBorder_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}