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
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 0, 0, 500, 400);

        // Add an Exponential trendline to the first series
        Aspose.Slides.Charts.ITrendline trendlineExp = chart.ChartData.Series[0].TrendLines.Add(
            Aspose.Slides.Charts.TrendlineType.Exponential);
        trendlineExp.DisplayEquation = false;
        trendlineExp.DisplayRSquaredValue = false;

        // Add a Linear trendline and set its line color to Red
        Aspose.Slides.Charts.ITrendline trendlineLin = chart.ChartData.Series[0].TrendLines.Add(
            Aspose.Slides.Charts.TrendlineType.Linear);
        trendlineLin.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        trendlineLin.Format.Line.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;

        // Add a Logarithmic trendline and add a custom text frame
        Aspose.Slides.Charts.ITrendline trendlineLog = chart.ChartData.Series[0].TrendLines.Add(
            Aspose.Slides.Charts.TrendlineType.Logarithmic);
        trendlineLog.AddTextFrameForOverriding("Logarithmic Trend");

        // Add a Moving Average trendline, set its period and name
        Aspose.Slides.Charts.ITrendline trendlineMA = chart.ChartData.Series[0].TrendLines.Add(
            Aspose.Slides.Charts.TrendlineType.MovingAverage);
        trendlineMA.Period = 3;
        trendlineMA.TrendlineName = "Moving Average";

        // Add a Polynomial trendline, set order and forward extension
        Aspose.Slides.Charts.ITrendline trendlinePoly = chart.ChartData.Series[0].TrendLines.Add(
            Aspose.Slides.Charts.TrendlineType.Polynomial);
        trendlinePoly.Order = 3;
        trendlinePoly.Forward = 2;

        // Add a Power trendline and set backward extension
        Aspose.Slides.Charts.ITrendline trendlinePower = chart.ChartData.Series[0].TrendLines.Add(
            Aspose.Slides.Charts.TrendlineType.Power);
        trendlinePower.Backward = 1;

        // Save the presentation
        presentation.Save("CustomizedTrendLines.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}