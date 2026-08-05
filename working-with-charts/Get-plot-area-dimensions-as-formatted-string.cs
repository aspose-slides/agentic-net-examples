// -----------------------------------------------------------------------------
// Example: Get plot area dimensions as formatted string using C#
//
// Description:
// Demonstrates how to get plot area dimensions as a formatted string using C# 
// and Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Plot, Area, Dimensions, 
// Formatted, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate get plot area dimensions as formatted string.
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
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add a clustered column chart to the first slide
                Chart chart = (Chart)presentation.Slides[0].Shapes.AddChart(
                    ChartType.ClusteredColumn, 50f, 50f, 600f, 400f);

                // Get formatted plot area dimensions
                string dimensions = GetPlotAreaDimensions(chart);
                Console.WriteLine(dimensions);

                // Save the presentation
                string outputPath = "OutputPresentation.pptx";
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // Returns a formatted string with the plot area dimensions of the given chart
        static string GetPlotAreaDimensions(IChart chart)
        {
            // Ensure layout is calculated
            chart.ValidateChartLayout();

            double x = chart.PlotArea.ActualX;
            double y = chart.PlotArea.ActualY;
            double width = chart.PlotArea.ActualWidth;
            double height = chart.PlotArea.ActualHeight;

            return $"Plot Area - X: {x}, Y: {y}, Width: {width}, Height: {height}";
        }
    }
}
