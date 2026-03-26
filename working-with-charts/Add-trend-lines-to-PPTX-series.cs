using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace TrendLineDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Assume the first slide contains a chart as the first shape
            ISlide slide = pres.Slides[0];
            IChart chart = (IChart)slide.Shapes[0];

            // Add various trend lines to the first series
            ITrendline exponentialTrend = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Exponential);
            exponentialTrend.DisplayEquation = false;
            exponentialTrend.DisplayRSquaredValue = false;

            ITrendline linearTrend = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
            linearTrend.Format.Line.FillFormat.FillType = FillType.Solid;
            linearTrend.Format.Line.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;

            ITrendline logarithmicTrend = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Logarithmic);
            logarithmicTrend.AddTextFrameForOverriding("Logarithmic Trend");

            ITrendline movingAverageTrend = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.MovingAverage);
            movingAverageTrend.Period = 3;
            movingAverageTrend.TrendlineName = "Moving Average (3)";

            ITrendline polynomialTrend = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Polynomial);
            polynomialTrend.Order = 2;
            polynomialTrend.Forward = 1.0;

            ITrendline powerTrend = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Power);
            powerTrend.Backward = 0.5;

            // Save the modified presentation
            pres.Save(outputPath, SaveFormat.Pptx);
        }
    }
}