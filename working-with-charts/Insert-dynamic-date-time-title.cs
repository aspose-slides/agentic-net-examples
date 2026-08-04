// -----------------------------------------------------------------------------
// Example: Insert dynamic date time title into a chart using C#
//
// Description:
// Demonstrates how to insert a dynamic date and time title into a chart
// within a PowerPoint presentation using C# and Aspose.Slides for .NET.
// The example creates a new presentation, adds a clustered column chart,
// sets the chart title to the current date and time, and saves the file.
// Developers can use this pattern to automate PPTX workflows, add timestamps
// to charts, or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Insert, Dynamic, Date, Time,
// Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate insertion of dynamic date/time titles into charts.
// - Build C# tools for PowerPoint chart processing with timestamps.
// - Generate or transform PPTX files with up-to-date chart titles in .NET
//   applications.
// - Validate chart title automation before publishing or integration.
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

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 500f, 400f);

        // Set chart title with current date and time
        chart.HasTitle = true;
        string titleText = "Report generated on " + DateTime.Now.ToString("g");
        chart.ChartTitle.AddTextFrameForOverriding(titleText);
        chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;
        chart.ChartTitle.Height = 30f;
        chart.ChartTitle.Width = 400f;
        chart.ChartTitle.Y = 10f;
        chart.ChartTitle.X = 100f;

        // Save the presentation
        presentation.Save("ChartWithDynamicTitle.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
