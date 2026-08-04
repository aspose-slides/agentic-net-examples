// -----------------------------------------------------------------------------
// Example: Validate negative trendline forward length bar using C#
//
// Description:
// Demonstrates how to validate negative trendline forward length bar using C# 
// and Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Validate, Negative, Trendline, 
// Forward, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate validate negative trendline forward length bar.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
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
            Presentation presentation = new Presentation();

            // Add a clustered column chart (bar chart) to the first slide
            ISlide slide = presentation.Slides[0];
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Add a linear trendline to the first series
            ITrendline trendline = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);

            // Set display options
            trendline.DisplayEquation = false;
            trendline.DisplayRSquaredValue = false;

            // Define forward length (example value)
            double forwardLength = -5.0; // This value is intentionally negative to demonstrate error handling

            // Validate forward length before assigning
            if (forwardLength < 0)
            {
                Console.WriteLine("Error: Forward length for trendline cannot be negative.");
            }
            else
            {
                trendline.Forward = forwardLength;
            }

            // Save the presentation
            try
            {
                presentation.Save("TrendlineExample.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other save errors
                Console.WriteLine("An error occurred while saving the presentation: " + ex.Message);
            }
        }
    }
}
