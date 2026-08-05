// -----------------------------------------------------------------------------
// Example: Validate negative forward length for trendline using C#
//
// Description:
// Demonstrates how to validate negative forward length for trendline using C# 
// and Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Validate, Negative, Forward, 
// Length, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate validate negative forward length for trendline.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace TrendLineBarChartExample
{
    class Program
    {
        static void Main()
        {
            // Output file path
            var outputPath = "TrendLineBarChart.pptx";

            // Create a new presentation
            var presentation = new Aspose.Slides.Presentation();

            // Add a clustered column (bar) chart to the first slide
            var chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50,   // X position
                50,   // Y position
                500,  // Width
                400   // Height
            );

            // Add a linear trend line to the first series
            var trendline = chart.ChartData.Series[0].TrendLines.Add(
                Aspose.Slides.Charts.TrendlineType.Linear
            );

            // Example forward length (could be from user input)
            var forwardLength = -5.0; // Negative value to trigger error handling

            // Validate forward length (must be non‑negative)
            if (forwardLength < 0)
            {
                Console.WriteLine("Error: Forward length cannot be negative.");
            }
            else
            {
                trendline.Forward = forwardLength;
            }

            // Save the presentation with error handling for unsupported formats
            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Format not supported or other saving issue
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
        }
    }
}
