using System;
using System.IO;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = args.Length > 0 ? args[0] : "input.pptx";
        string outputPath = args.Length > 1 ? args[1] : "output_with_trendlines.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.IShape shape = slide.Shapes[0];
            Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;
            if (chart != null)
            {
                // Exponential trend line
                Aspose.Slides.Charts.ITrendline expTrend = chart.ChartData.Series[0].TrendLines.Add(Aspose.Slides.Charts.TrendlineType.Exponential);
                expTrend.DisplayEquation = false;
                expTrend.DisplayRSquaredValue = false;

                // Linear trend line with red line color
                Aspose.Slides.Charts.ITrendline linearTrend = chart.ChartData.Series[0].TrendLines.Add(Aspose.Slides.Charts.TrendlineType.Linear);
                linearTrend.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                linearTrend.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

                // Logarithmic trend line with custom text
                Aspose.Slides.Charts.ITrendline logTrend = chart.ChartData.Series[0].TrendLines.Add(Aspose.Slides.Charts.TrendlineType.Logarithmic);
                logTrend.AddTextFrameForOverriding("Log Trend");

                // Moving average trend line
                Aspose.Slides.Charts.ITrendline maTrend = chart.ChartData.Series[0].TrendLines.Add(Aspose.Slides.Charts.TrendlineType.MovingAverage);
                maTrend.Period = 2;
                maTrend.TrendlineName = "MA 2";

                // Polynomial trend line
                Aspose.Slides.Charts.ITrendline polyTrend = chart.ChartData.Series[0].TrendLines.Add(Aspose.Slides.Charts.TrendlineType.Polynomial);
                polyTrend.Order = 3;
                polyTrend.Forward = 1;

                // Power trend line
                Aspose.Slides.Charts.ITrendline powerTrend = chart.ChartData.Series[0].TrendLines.Add(Aspose.Slides.Charts.TrendlineType.Power);
                powerTrend.Backward = 1;
            }

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}