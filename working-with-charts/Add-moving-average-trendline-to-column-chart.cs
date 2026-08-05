// -----------------------------------------------------------------------------
// Example: Add moving average trendline to column chart using C#
//
// Description:
// Demonstrates how to add a moving average trendline to a clustered column chart 
// using C# and Aspose.Slides for .NET. The example creates a new presentation, 
// inserts a column chart, adds a moving average trendline to the first data series, 
// configures its properties, and saves the result as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Moving Average, Trendline, 
// Column Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate the addition of moving average trendlines to column charts in PPTX files.
// - Build C# utilities for PowerPoint chart manipulation and analysis.
// - Generate or modify presentations with statistical trendlines in .NET applications.
// - Validate chart trendline configurations before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TrendLineExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add a clustered column chart on the first slide
                IChart chart = presentation.Slides[0].Shapes.AddChart(
                    ChartType.ClusteredColumn,
                    0f, 0f, 500f, 400f);

                // Add a moving average trend line to the first series
                ITrendline trendline = chart.ChartData.Series[0].TrendLines.Add(
                    TrendlineType.MovingAverage);

                // Configure the trend line
                trendline.DisplayEquation = false;
                trendline.DisplayRSquaredValue = false;
                trendline.Period = 3; // Example period

                // Save the presentation
                presentation.Save("TrendLineChart.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
