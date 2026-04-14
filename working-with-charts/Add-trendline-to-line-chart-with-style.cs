using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a clustered column chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

        // Add a linear trend line to the first series
        Aspose.Slides.Charts.ITrendline trendline = chart.ChartData.Series[0].TrendLines.Add(
            Aspose.Slides.Charts.TrendlineType.Linear);

        // Hide equation and R-squared value
        trendline.DisplayEquation = false;
        trendline.DisplayRSquaredValue = false;

        // Customize the trend line appearance (solid red line)
        trendline.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        trendline.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

        // Save the presentation
        presentation.Save("TrendlineDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}