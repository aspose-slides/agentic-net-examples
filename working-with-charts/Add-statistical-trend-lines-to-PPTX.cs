using System;
using System.IO;
using Aspose.Slides.Export;
using System.Drawing;

namespace TrendLineExample
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: TrendLineExample <input.pptx> <output.pptx>");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
                Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 600f, 400f);

                // Exponential trendline
                Aspose.Slides.Charts.ITrendline expTrend = chart.ChartData.Series[0].TrendLines.Add(Aspose.Slides.Charts.TrendlineType.Exponential);
                expTrend.DisplayEquation = false;
                expTrend.DisplayRSquaredValue = false;

                // Linear trendline with red line
                Aspose.Slides.Charts.ITrendline linearTrend = chart.ChartData.Series[0].TrendLines.Add(Aspose.Slides.Charts.TrendlineType.Linear);
                linearTrend.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                linearTrend.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

                // Logarithmic trendline with custom text
                Aspose.Slides.Charts.ITrendline logTrend = chart.ChartData.Series[0].TrendLines.Add(Aspose.Slides.Charts.TrendlineType.Logarithmic);
                logTrend.AddTextFrameForOverriding("Logarithmic Trendline");

                // Moving average trendline
                Aspose.Slides.Charts.ITrendline maTrend = chart.ChartData.Series[0].TrendLines.Add(Aspose.Slides.Charts.TrendlineType.MovingAverage);
                maTrend.Period = 3;
                maTrend.TrendlineName = "MA Trendline";

                // Polynomial trendline
                Aspose.Slides.Charts.ITrendline polyTrend = chart.ChartData.Series[0].TrendLines.Add(Aspose.Slides.Charts.TrendlineType.Polynomial);
                polyTrend.Order = 2;
                polyTrend.Forward = 1.0;

                // Power trendline
                Aspose.Slides.Charts.ITrendline powerTrend = chart.ChartData.Series[0].TrendLines.Add(Aspose.Slides.Charts.TrendlineType.Power);
                powerTrend.Backward = 0.5;

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}