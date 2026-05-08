using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = "BubbleChartConditionalFormatting.pptx";

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a bubble chart to the first slide
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Bubble,
                50f, 50f, 600f, 400f);

            // Get the first series of the chart
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

            // Configure data source types to use literal double values
            series.DataPoints.DataSourceTypeForXValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
            series.DataPoints.DataSourceTypeForYValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
            series.DataPoints.DataSourceTypeForBubbleSizes = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;

            // Threshold for conditional formatting
            double threshold = 50.0;

            // Sample data: (X, Y, BubbleSize)
            double[,] data = new double[,]
            {
                { 10, 30, 15 },
                { 20, 60, 20 },
                { 30, 45, 25 },
                { 40, 80, 30 },
                { 50, 55, 35 }
            };

            // Add data points and apply conditional color
            for (int i = 0; i < data.GetLength(0); i++)
            {
                double x = data[i, 0];
                double y = data[i, 1];
                double size = data[i, 2];

                Aspose.Slides.Charts.IChartDataPoint point = series.DataPoints.AddDataPointForBubbleSeries(x, y, size);

                // If Y value exceeds the threshold, color the bubble red
                if (y > threshold)
                {
                    point.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                    point.Format.Fill.SolidFillColor.Color = System.Drawing.Color.Red;
                }
            }

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}