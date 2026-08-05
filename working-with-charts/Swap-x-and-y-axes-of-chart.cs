// -----------------------------------------------------------------------------
// Example: Swap x and y axes of chart using C#
//
// Description:
// Demonstrates how to create a new presentation, add a clustered column chart,
// swap the data between the X and Y axes of the chart, and save the result as
// a PPTX file using Aspose.Slides for .NET. This example shows the essential
// steps for chart manipulation in PowerPoint files within a console
// application.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Swap, Axes, Chart, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate swapping of X and Y axes in chart data.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files with modified chart orientations.
// - Validate chart data transformations before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a clustered column chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 450f, 300f);

        // Swap the data between the X and Y axes
        chart.ChartData.SwitchRowColumn();

        // Save the presentation
        string outputPath = "SwapAxesChart.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
