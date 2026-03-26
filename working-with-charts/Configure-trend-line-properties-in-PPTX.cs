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
        Presentation presentation = new Presentation();

        // Add a clustered column chart on the first slide
        IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

        // Add an exponential trendline to the first series
        ITrendline expTrendline = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Exponential);
        expTrendline.DisplayEquation = false;
        expTrendline.DisplayRSquaredValue = false;

        // Add a linear trendline to the second series and set its line color to red
        ITrendline linearTrendline = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Linear);
        linearTrendline.Format.Line.FillFormat.FillType = FillType.Solid;
        linearTrendline.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

        // Add a polynomial trendline to the first series with order 3 and forward 2
        ITrendline polyTrendline = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Polynomial);
        polyTrendline.Order = 3;
        polyTrendline.Forward = 2;

        // Save the presentation
        presentation.Save("TrendlineExample.pptx", SaveFormat.Pptx);
    }
}