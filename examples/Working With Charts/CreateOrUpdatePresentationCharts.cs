using System;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a clustered column chart with sample data
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 0f, 0f, 500f, 400f);

        // ----- Exponential trend line -----
        Aspose.Slides.Charts.ITrendline exponentialTrend = chart.ChartData.Series[0].TrendLines.Add(
            Aspose.Slides.Charts.TrendlineType.Exponential);
        exponentialTrend.DisplayEquation = false;
        exponentialTrend.DisplayRSquaredValue = false;

        // ----- Linear trend line -----
        Aspose.Slides.Charts.ITrendline linearTrend = chart.ChartData.Series[0].TrendLines.Add(
            Aspose.Slides.Charts.TrendlineType.Linear);
        linearTrend.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        linearTrend.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

        // ----- Logarithmic trend line -----
        Aspose.Slides.Charts.ITrendline logarithmicTrend = chart.ChartData.Series[0].TrendLines.Add(
            Aspose.Slides.Charts.TrendlineType.Logarithmic);
        logarithmicTrend.AddTextFrameForOverriding("Logarithmic Trend");

        // ----- Moving Average trend line -----
        Aspose.Slides.Charts.ITrendline movingAverageTrend = chart.ChartData.Series[0].TrendLines.Add(
            Aspose.Slides.Charts.TrendlineType.MovingAverage);
        movingAverageTrend.Period = 3;
        movingAverageTrend.TrendlineName = "MA (3)";

        // ----- Polynomial trend line -----
        Aspose.Slides.Charts.ITrendline polynomialTrend = chart.ChartData.Series[0].TrendLines.Add(
            Aspose.Slides.Charts.TrendlineType.Polynomial);
        polynomialTrend.Order = 2;      // Quadratic
        polynomialTrend.Forward = 1;    // Extend forward by 1 unit

        // ----- Power trend line -----
        Aspose.Slides.Charts.ITrendline powerTrend = chart.ChartData.Series[0].TrendLines.Add(
            Aspose.Slides.Charts.TrendlineType.Power);
        powerTrend.Backward = 1;        // Extend backward by 1 unit

        // Save the presentation
        presentation.Save("ChartTrendLines_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}