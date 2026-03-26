using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

namespace TrendLineExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load existing presentation if it exists, otherwise create a new one
            if (File.Exists(inputPath))
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    AddChartWithTrendLines(presentation);
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            else
            {
                using (Presentation presentation = new Presentation())
                {
                    AddChartWithTrendLines(presentation);
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
        }

        private static void AddChartWithTrendLines(Presentation presentation)
        {
            // Add a clustered column chart to the first slide
            IChart chart = presentation.Slides[0].Shapes.AddChart(
                ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

            // Ensure there is at least one series; if not, add a sample series
            if (chart.ChartData.Series.Count == 0)
            {
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                chart.ChartData.Series.Add(workbook.GetCell(0, 1, 1, "Series 1"), chart.Type);
                chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));
                IChartSeries series = chart.ChartData.Series[0];
                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 20));
                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 40));
                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 30));
            }

            // Add various trend lines to the first series
            ITrendline exponentialTrend = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Exponential);
            exponentialTrend.DisplayEquation = false;
            exponentialTrend.DisplayRSquaredValue = false;

            ITrendline linearTrend = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
            linearTrend.Format.Line.FillFormat.FillType = FillType.Solid;
            linearTrend.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

            ITrendline logarithmicTrend = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Logarithmic);
            logarithmicTrend.AddTextFrameForOverriding("Logarithmic Trend");

            ITrendline movingAverageTrend = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.MovingAverage);
            movingAverageTrend.Period = 3;
            movingAverageTrend.TrendlineName = "Moving Avg";

            ITrendline polynomialTrend = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Polynomial);
            polynomialTrend.Order = 3;
            polynomialTrend.Forward = 2;

            ITrendline powerTrend = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Power);
            powerTrend.Backward = 1;
        }
    }
}