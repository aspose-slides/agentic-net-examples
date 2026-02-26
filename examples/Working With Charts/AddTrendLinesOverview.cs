using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AddTrendLinesOverview
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a clustered column chart to the first slide
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn, 0f, 0f, 500f, 400f);

            // Exponential trend line
            Aspose.Slides.Charts.ITrendline exponentialTrend = chart.ChartData.Series[0].TrendLines.Add(
                Aspose.Slides.Charts.TrendlineType.Exponential);
            exponentialTrend.DisplayEquation = false;
            exponentialTrend.DisplayRSquaredValue = false;

            // Linear trend line with red solid line
            Aspose.Slides.Charts.ITrendline linearTrend = chart.ChartData.Series[0].TrendLines.Add(
                Aspose.Slides.Charts.TrendlineType.Linear);
            linearTrend.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            linearTrend.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

            // Logarithmic trend line with custom text
            Aspose.Slides.Charts.ITrendline logarithmicTrend = chart.ChartData.Series[0].TrendLines.Add(
                Aspose.Slides.Charts.TrendlineType.Logarithmic);
            logarithmicTrend.AddTextFrameForOverriding("Log Trend");

            // Moving average trend line
            Aspose.Slides.Charts.ITrendline movingAvgTrend = chart.ChartData.Series[0].TrendLines.Add(
                Aspose.Slides.Charts.TrendlineType.MovingAverage);
            movingAvgTrend.Period = 3;
            movingAvgTrend.TrendlineName = "3-Period MA";

            // Polynomial trend line
            Aspose.Slides.Charts.ITrendline polynomialTrend = chart.ChartData.Series[0].TrendLines.Add(
                Aspose.Slides.Charts.TrendlineType.Polynomial);
            polynomialTrend.Order = 3;
            polynomialTrend.Forward = 2.0;

            // Power trend line
            Aspose.Slides.Charts.ITrendline powerTrend = chart.ChartData.Series[0].TrendLines.Add(
                Aspose.Slides.Charts.TrendlineType.Power);
            powerTrend.Backward = 1.5;

            // Save the presentation
            presentation.Save("TrendLinesOverview.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}