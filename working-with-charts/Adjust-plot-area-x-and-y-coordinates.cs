// -----------------------------------------------------------------------------
// Example: Adjust plot area x and y coordinates using C#
//
// Description:
// Demonstrates how to adjust plot area x and y coordinates using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Adjust, Plot, Area, 
// Coordinates, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adjust plot area x and y coordinates.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Add a clustered column chart to the first slide
        IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

        // Calculate actual layout values for the chart elements
        chart.ValidateChartLayout();

        // Retrieve the actual X and Y positions of the plot area (in points)
        float actualX = chart.PlotArea.ActualX;
        float actualY = chart.PlotArea.ActualY;

        // The chart's width and height (as defined when adding the chart)
        float chartWidth = 500f;
        float chartHeight = 400f;

        // Adjust the plot area position manually using the retrieved actual values.
        // PlotArea.X and PlotArea.Y expect fractions of the chart's width/height.
        chart.PlotArea.AsILayoutable.X = actualX / chartWidth;
        chart.PlotArea.AsILayoutable.Y = actualY / chartHeight;

        // Optionally define how the plot area layout is calculated
        chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;

        // Save the modified presentation
        presentation.Save("AdjustedPlotArea.pptx", SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}
