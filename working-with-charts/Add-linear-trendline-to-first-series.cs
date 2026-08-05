// -----------------------------------------------------------------------------
// Example: Add linear trendline to first series using C#
//
// Description:
// Demonstrates how to add a linear trendline to the first data series of a
// clustered column chart using C# and Aspose.Slides for .NET. The example
// creates a new presentation, inserts a chart, adds a linear trendline to the
// first series, and saves the presentation as a PPTX file. This pattern can be
// used to automate chart enhancements in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Linear Trendline, First Series,
// Chart Automation, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a linear trendline to the first series of a chart.
// - Build C# utilities for enhancing PowerPoint charts.
// - Generate or modify PPTX files with trendlines in .NET applications.
// - Validate chart data visualizations before publishing.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesTrendLineExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a clustered column chart to the first slide
            IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 600f, 400f);

            // Add a linear trend line to the first data series
            ITrendline linearTrend = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
            linearTrend.DisplayEquation = false;
            linearTrend.DisplayRSquaredValue = false;

            // Save the presentation
            try
            {
                presentation.Save("TrendLineExample.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during saving
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}
