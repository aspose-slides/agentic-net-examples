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
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add a clustered column chart to the first slide
        Aspose.Slides.Charts.IChart chart = pres.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            0f, 0f, 500f, 400f);

        // Change the fill color of the first series to red
        chart.ChartData.Series[0].Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        chart.ChartData.Series[0].Format.Fill.SolidFillColor.Color = Color.Red;

        // Save the presentation
        pres.Save("ChangeSeriesFillColor_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}