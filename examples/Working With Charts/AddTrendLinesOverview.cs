using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a clustered column chart on the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50, 50, 500, 400);

        // Add Exponential trendline to the first series
        Aspose.Slides.Charts.ITrendline exponentialTrend = chart.ChartData.Series[0].TrendLines.Add(
            Aspose.Slides.Charts.TrendlineType.Exponential);
        exponentialTrend.DisplayEquation = false;
        exponentialTrend.DisplayRSquaredValue = false;

        // Add Linear trendline and set its line color to red
        Aspose.Slides.Charts.ITrendline linearTrend = chart.ChartData.Series[0].TrendLines.Add(
            Aspose.Slides.Charts.TrendlineType.Linear);
        linearTrend.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        linearTrend.Format.Line.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;

        // Add Logarithmic trendline with custom text
        Aspose.Slides.Charts.ITrendline logarithmicTrend = chart.ChartData.Series[0].TrendLines.Add(
            Aspose.Slides.Charts.TrendlineType.Logarithmic);
        logarithmicTrend.AddTextFrameForOverriding("Logarithmic Trend");

        // Add Moving Average trendline with period and name
        Aspose.Slides.Charts.ITrendline movingAvgTrend = chart.ChartData.Series[0].TrendLines.Add(
            Aspose.Slides.Charts.TrendlineType.MovingAverage);
        movingAvgTrend.Period = 3;
        movingAvgTrend.TrendlineName = "3-Period MA";

        // Add Polynomial trendline with order and forward extension
        Aspose.Slides.Charts.ITrendline polynomialTrend = chart.ChartData.Series[0].TrendLines.Add(
            Aspose.Slides.Charts.TrendlineType.Polynomial);
        polynomialTrend.Order = 3;
        polynomialTrend.Forward = 2;

        // Add Power trendline with backward extension
        Aspose.Slides.Charts.ITrendline powerTrend = chart.ChartData.Series[0].TrendLines.Add(
            Aspose.Slides.Charts.TrendlineType.Power);
        powerTrend.Backward = 1;

        // Save the presentation
        presentation.Save("TrendLinesOverview.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}