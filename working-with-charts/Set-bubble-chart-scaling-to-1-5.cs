using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace BubbleChartScalingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = "BubbleChartScaling.pptx";

            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Add a bubble chart to the first slide (position and size are in points)
                IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50f, 50f, 500f, 400f);

                // Set bubble size scaling factor to 150% (1.5 times)
                chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;

                // Access the first series of the chart
                IChartSeries series = chart.ChartData.Series[0];

                // Configure data source types to accept literal double values
                series.DataPoints.DataSourceTypeForXValues = DataSourceType.DoubleLiterals;
                series.DataPoints.DataSourceTypeForYValues = DataSourceType.DoubleLiterals;
                series.DataPoints.DataSourceTypeForBubbleSizes = DataSourceType.DoubleLiterals;

                // Add bubble data points (x, y, bubble size) using double literals
                series.DataPoints.AddDataPointForBubbleSeries(1.0, 2.0, 10.0);
                series.DataPoints.AddDataPointForBubbleSeries(2.0, 3.5, 20.0);
                series.DataPoints.AddDataPointForBubbleSeries(3.0, 1.5, 15.0);

                // Save the presentation
                try
                {
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
                catch (ArgumentException ex)
                {
                    // Handle unsupported format exception
                    // Format not supported
                    Console.WriteLine("Error saving presentation: " + ex.Message);
                }
            }
        }
    }
}