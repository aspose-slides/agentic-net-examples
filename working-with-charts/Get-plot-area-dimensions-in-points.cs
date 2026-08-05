// -----------------------------------------------------------------------------
// Example: Get plot area dimensions in points using C#
//
// Description:
// Demonstrates how to retrieve the plot area dimensions (ActualX, ActualY,
// ActualWidth, ActualHeight) in points using C# and Aspose.Slides for .NET.
// The example creates a new presentation, adds a clustered column chart,
// accesses the chart's PlotArea properties, outputs the values to the console,
// and saves the presentation. This pattern helps developers automate PPTX
// workflows that require precise chart layout information.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Plot Area, Dimensions, Points,
// Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of chart plot area dimensions in points.
// - Build C# tools for PowerPoint presentation analysis and validation.
// - Generate or modify PPTX files with precise chart layout handling.
// - Integrate chart dimension retrieval into .NET applications for reporting.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var inputPath = "input.pptx";
        var outputPath = "output.pptx";

        var presentation = new Aspose.Slides.Presentation();

        var chart = (Aspose.Slides.Charts.Chart)presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 100f, 100f, 500f, 350f);
        chart.ValidateChartLayout();

        var x = chart.PlotArea.ActualX;
        var y = chart.PlotArea.ActualY;
        var w = chart.PlotArea.ActualWidth;
        var h = chart.PlotArea.ActualHeight;

        Console.WriteLine($"PlotArea ActualX: {x}, ActualY: {y}, ActualWidth: {w}, ActualHeight: {h}");

        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}
