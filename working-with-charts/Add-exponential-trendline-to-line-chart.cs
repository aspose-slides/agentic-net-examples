// -----------------------------------------------------------------------------
// Example: Add exponential trendline to line chart using C#
//
// Description:
// Demonstrates how to add an exponential trendline to a line chart using C# 
// and Aspose.Slides for .NET. The example creates a presentation, inserts a 
// line chart with sample data, adds an exponential trendline to the first 
// series, and saves the result as a PPTX file. This pattern can be used to 
// automate PowerPoint chart enhancements in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Exponential, Trendline, Line, 
// Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding exponential trendlines to line charts in presentations.
// - Build C# tools for PowerPoint chart manipulation and analysis.
// - Generate or modify PPTX files with advanced chart features in .NET.
// - Validate chart data visualizations before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Add a line chart with sample data to the first slide
            IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 50f, 50f, 500f, 400f, true);

            // Ensure the chart type supports trend lines
            if (ChartTypeCharacterizer.HasSeriesTrendLines(chart.Type))
            {
                // Add an exponential trend line to the first series
                ITrendline expTrendline = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Exponential);
                expTrendline.DisplayEquation = false;
                expTrendline.DisplayRSquaredValue = false;
            }

            // Save the presentation
            try
            {
                pres.Save("LineChartWithExponentialTrendline.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle cases where the format is not supported
                // Format not supported: ex.Message
            }

            // Dispose the presentation
            pres.Dispose();
        }
    }
}
