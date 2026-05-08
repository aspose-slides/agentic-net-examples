using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a clustered column chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50,   // X position
            50,   // Y position
            500,  // Width
            400   // Height
        );

        // Add a linear trend line to the first series
        Aspose.Slides.Charts.ITrendline trendline = chart.ChartData.Series[0].TrendLines.Add(
            Aspose.Slides.Charts.TrendlineType.Linear
        );

        // Customize the trend line appearance
        trendline.DisplayEquation = false;
        trendline.DisplayRSquaredValue = false;
        trendline.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        trendline.Format.Line.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;

        // Save the presentation
        try
        {
            presentation.Save("TrendLineDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Handle exceptions such as unsupported format
        }
    }
}