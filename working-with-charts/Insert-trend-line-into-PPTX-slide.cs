using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace TrendlineDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Add a clustered column chart to the first slide
            Aspose.Slides.Charts.IChart chart = pres.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn, 0f, 0f, 500f, 400f);

            // Add an exponential trendline and hide its equation and R-squared value
            Aspose.Slides.Charts.ITrendline expTrend = chart.ChartData.Series[0].TrendLines.Add(
                Aspose.Slides.Charts.TrendlineType.Exponential);
            expTrend.DisplayEquation = false;
            expTrend.DisplayRSquaredValue = false;

            // Add a linear trendline and set its line color to red
            Aspose.Slides.Charts.ITrendline linearTrend = chart.ChartData.Series[0].TrendLines.Add(
                Aspose.Slides.Charts.TrendlineType.Linear);
            linearTrend.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            linearTrend.Format.Line.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;

            // Add a logarithmic trendline with custom text
            Aspose.Slides.Charts.ITrendline logTrend = chart.ChartData.Series[0].TrendLines.Add(
                Aspose.Slides.Charts.TrendlineType.Logarithmic);
            logTrend.AddTextFrameForOverriding("Logarithmic Trend");

            // Add a moving average trendline with period and name
            Aspose.Slides.Charts.ITrendline maTrend = chart.ChartData.Series[0].TrendLines.Add(
                Aspose.Slides.Charts.TrendlineType.MovingAverage);
            maTrend.Period = 3;
            maTrend.TrendlineName = "Moving Average (3)";

            // Add a polynomial trendline with order and forward extension
            Aspose.Slides.Charts.ITrendline polyTrend = chart.ChartData.Series[0].TrendLines.Add(
                Aspose.Slides.Charts.TrendlineType.Polynomial);
            polyTrend.Order = 2;
            polyTrend.Forward = 1;

            // Add a power trendline with backward extension
            Aspose.Slides.Charts.ITrendline powerTrend = chart.ChartData.Series[0].TrendLines.Add(
                Aspose.Slides.Charts.TrendlineType.Power);
            powerTrend.Backward = 2;

            // Save the presentation
            pres.Save("TrendlineDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}