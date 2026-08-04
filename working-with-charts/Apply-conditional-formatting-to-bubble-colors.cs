// -----------------------------------------------------------------------------
// Example: Apply conditional formatting to bubble colors using C#
//
// Description:
// Demonstrates how to apply conditional formatting to bubble colors in a
// bubble chart using C# and Aspose.Slides for .NET. The example creates a
// presentation, adds a bubble chart, populates it with sample data, and
// colors bubbles red when their Y‑value exceeds a defined threshold.
// This pattern can be used to automate PPTX workflows, validate results, or
// integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Conditional, Formatting,
// Bubble, Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate conditional formatting of bubble chart colors based on data values.
// - Build C# tools for PowerPoint chart manipulation and presentation processing.
// - Generate or transform PPTX files with customized chart styling in .NET applications.
// - Validate chart data visualizations before publishing or integration.
// -----------------------------------------------------------------------------

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
            Presentation presentation = new Presentation();

            // Add a bubble chart to the first slide
            IChart chart = presentation.Slides[0].Shapes.AddChart(
                ChartType.Bubble,
                50f, 50f, 600f, 400f);

            // Get the first series of the chart
            IChartSeries series = chart.ChartData.Series[0];

            // Configure data source types to use literal double values
            series.DataPoints.DataSourceTypeForXValues = DataSourceType.DoubleLiterals;
            series.DataPoints.DataSourceTypeForYValues = DataSourceType.DoubleLiterals;
            series.DataPoints.DataSourceTypeForBubbleSizes = DataSourceType.DoubleLiterals;

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

                IChartDataPoint point = series.DataPoints.AddDataPointForBubbleSeries(x, y, size);

                // If Y value exceeds the threshold, color the bubble red
                if (y > threshold)
                {
                    point.Format.Fill.FillType = FillType.Solid;
                    point.Format.Fill.SolidFillColor.Color = Color.Red;
                }
            }

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}
