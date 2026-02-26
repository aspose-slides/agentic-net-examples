using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AddTrendLinesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                0f, 0f, 500f, 400f);

            // ----- Add various trend lines to the first series -----

            // Exponential trend line (hide equation and R‑squared)
            Aspose.Slides.Charts.ITrendline exponentialTrendline = chart.ChartData.Series[0].TrendLines.Add(
                Aspose.Slides.Charts.TrendlineType.Exponential);
            exponentialTrendline.DisplayEquation = false;
            exponentialTrendline.DisplayRSquaredValue = false;

            // Linear trend line with red solid line
            Aspose.Slides.Charts.ITrendline linearTrendline = chart.ChartData.Series[0].TrendLines.Add(
                Aspose.Slides.Charts.TrendlineType.Linear);
            linearTrendline.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            linearTrendline.Format.Line.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;

            // Logarithmic trend line with custom text
            Aspose.Slides.Charts.ITrendline logarithmicTrendline = chart.ChartData.Series[0].TrendLines.Add(
                Aspose.Slides.Charts.TrendlineType.Logarithmic);
            logarithmicTrendline.AddTextFrameForOverriding("Logarithmic Trend");

            // Moving average trend line (period = 3) with a name
            Aspose.Slides.Charts.ITrendline movingAverageTrendline = chart.ChartData.Series[0].TrendLines.Add(
                Aspose.Slides.Charts.TrendlineType.MovingAverage);
            movingAverageTrendline.Period = 3;
            movingAverageTrendline.TrendlineName = "MA(3)";

            // Polynomial trend line (order = 2) extending forward
            Aspose.Slides.Charts.ITrendline polynomialTrendline = chart.ChartData.Series[0].TrendLines.Add(
                Aspose.Slides.Charts.TrendlineType.Polynomial);
            polynomialTrendline.Order = 2;
            polynomialTrendline.Forward = 1;

            // Power trend line extending backward
            Aspose.Slides.Charts.ITrendline powerTrendline = chart.ChartData.Series[0].TrendLines.Add(
                Aspose.Slides.Charts.TrendlineType.Power);
            powerTrendline.Backward = 2;

            // Save the presentation
            presentation.Save("AddTrendLines_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}