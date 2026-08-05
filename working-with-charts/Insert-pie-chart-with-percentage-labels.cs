// -----------------------------------------------------------------------------
// Example: Insert pie chart with percentage labels using C#
//
// Description:
// Demonstrates how to insert a pie chart with percentage data labels using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Insert, Chart, Percentage, 
// Labels, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate insertion of pie charts with percentage labels.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the title slide (first slide)
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a pie chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 50f, 100f, 400f, 300f);

        // Display percentage labels for the first series
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowPercentage = true;

        // Optionally hide the raw value labels
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = false;

        // Save the presentation
        try
        {
            presentation.Save("PieChartWithPercentages.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
    }
}
