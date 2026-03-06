using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart with sample data
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            0f, 0f, 500f, 400f);

        // Add a linear trend line to the first series
        Aspose.Slides.Charts.ITrendline trendline = chart.ChartData.Series[0]
            .TrendLines.Add(Aspose.Slides.Charts.TrendlineType.Linear);

        // Configure trend line appearance
        trendline.DisplayEquation = false;
        trendline.DisplayRSquaredValue = false;
        trendline.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        trendline.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

        // Save the presentation
        presentation.Save("AddTrendLine_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}