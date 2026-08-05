// -----------------------------------------------------------------------------
// Example: Get plot area actual dimensions in points using C#
//
// Description:
// Demonstrates how to retrieve the actual X, Y, width, and height of a chart's
// plot area in points using C# and Aspose.Slides for .NET. The example creates
// a presentation, adds a clustered column chart, obtains the plot area layout
// values, outputs them to the console, and saves the presentation.
// This pattern helps developers automate PowerPoint chart analysis and
// integrate layout validation into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Plot Area, Actual Dimensions, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of chart plot area dimensions in points.
// - Build C# utilities for PowerPoint chart layout inspection.
// - Validate chart rendering before publishing or further processing.
// - Integrate chart dimension data into reporting or analytics workflows.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.IO;

class Program
{
    static void Main()
    {
        // Define output path
        string outputPath = "ChartPlotAreaOutput.pptx";

        // Create a new presentation
        Presentation presentation = new Presentation();

        // Add a chart to the first slide
        Chart chart = (Chart)presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100f, 100f, 500f, 350f);
        chart.ValidateChartLayout();

        // Retrieve actual layout values
        double actualX = chart.PlotArea.ActualX;
        double actualY = chart.PlotArea.ActualY;
        double actualWidth = chart.PlotArea.ActualWidth;
        double actualHeight = chart.PlotArea.ActualHeight;

        // Output the retrieved values
        Console.WriteLine("ActualX: " + actualX);
        Console.WriteLine("ActualY: " + actualY);
        Console.WriteLine("ActualWidth: " + actualWidth);
        Console.WriteLine("ActualHeight: " + actualHeight);

        // Save the presentation
        presentation.Save(outputPath, SaveFormat.Pptx);
    }
}
