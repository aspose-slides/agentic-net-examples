// -----------------------------------------------------------------------------
// Example: Clone chart enable data table and place using C#
//
// Description:
// Demonstrates how to clone a slide that contains a chart with its data table
// enabled and place the cloned slide within a presentation using C# and 
// Aspose.Slides for .NET. The example shows the required presentation-processing 
// steps for PowerPoint files and produces the requested output in a standalone 
// console application. Developers can use this pattern to automate PPTX workflows, 
// validate results, or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone, Chart, Enable, Data Table, 
// Slide, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate cloning of a chart with an enabled data table and placing it in a 
//   presentation.
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
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide firstSlide = presentation.Slides[0];

        // Add a clustered column chart to the first slide
        Aspose.Slides.Charts.IChart originalChart = firstSlide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 500f, 400f);

        // Enable the data table for the chart
        originalChart.HasDataTable = true;

        // Clone the slide containing the chart and insert it at index 1 (second slide)
        Aspose.Slides.ISlide clonedSlide = presentation.Slides.InsertClone(1, firstSlide);

        // Save the presentation
        string outputPath = "ClonedChartPresentation.pptx";
        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // If the file format is not supported, handle accordingly
            // format not supported
        }
    }
}
