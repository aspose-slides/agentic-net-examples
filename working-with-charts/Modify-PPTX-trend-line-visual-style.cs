using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ModifyTrendLine
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            try
            {
                using (Presentation pres = new Presentation(inputPath))
                {
                    IShape shape = pres.Slides[0].Shapes[0];
                    IChart chart = shape as IChart;

                    if (chart != null)
                    {
                        IChartSeries series = chart.ChartData.Series[0];

                        ITrendline trendline;
                        if (series.TrendLines.Count > 0)
                        {
                            trendline = series.TrendLines[0];
                        }
                        else
                        {
                            trendline = series.TrendLines.Add(TrendlineType.Linear);
                        }

                        // Modify visual attributes
                        trendline.DisplayEquation = false;
                        trendline.DisplayRSquaredValue = false;
                        trendline.Format.Line.FillFormat.FillType = FillType.Solid;
                        trendline.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

                        // Example of additional styling
                        trendline.Forward = 2.0;
                        trendline.Backward = 1.0;
                        trendline.TrendlineName = "Custom Trendline";
                    }

                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}