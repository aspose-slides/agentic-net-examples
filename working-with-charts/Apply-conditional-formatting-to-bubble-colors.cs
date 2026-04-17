using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a bubble chart to the first slide
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Bubble,
                50f, 50f, 500f, 400f);

            // Get the first series of the chart
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

            // Configure the series to accept literal double values for X, Y, Values and BubbleSize
            series.DataPoints.DataSourceTypeForXValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
            series.DataPoints.DataSourceTypeForYValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
            series.DataPoints.DataSourceTypeForValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
            series.DataPoints.DataSourceTypeForBubbleSizes = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;

            // Sample data for the bubble chart
            double[] xValues = new double[] { 1, 2, 3, 4, 5 };
            double[] yValues = new double[] { 10, 20, 30, 40, 50 };
            double[] bubbleSizes = new double[] { 5, 10, 15, 20, 25 };

            // Add data points using literal values
            for (int i = 0; i < xValues.Length; i++)
            {
                series.DataPoints.AddDataPointForBubbleSeries(
                    xValues[i],
                    yValues[i],
                    bubbleSizes[i]);
            }

            // Conditional formatting: color bubbles red when Y value exceeds the threshold
            double threshold = 30.0;
            for (int i = 0; i < series.DataPoints.Count; i++)
            {
                Aspose.Slides.Charts.IChartDataPoint point = series.DataPoints[i];
                double yValue = point.YValue.AsLiteralDouble;
                if (yValue > threshold)
                {
                    point.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                    point.Format.Fill.SolidFillColor.Color = System.Drawing.Color.Red;
                }
            }

            // Save the presentation
            try
            {
                presentation.Save("BubbleChartConditionalFormatting.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception)
            {
                // Format not supported
            }
        }
    }
}