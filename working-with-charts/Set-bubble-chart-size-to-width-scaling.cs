// -----------------------------------------------------------------------------
// Example: Set bubble chart size to width scaling using C#
//
// Description:
// Demonstrates how to create a bubble chart in a PowerPoint presentation and
// configure its bubble size representation to use width scaling. The example
// uses Aspose.Slides for .NET to add a bubble chart, set the
// BubbleSizeRepresentation property to Width, and save the resulting PPTX file.
// This pattern helps developers automate chart formatting tasks in PPTX files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Bubble Chart, Size Scaling, Width,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting bubble chart size to width scaling in presentations.
// - Build C# utilities for customizing chart appearance in PowerPoint files.
// - Generate or modify PPTX files with specific chart scaling requirements.
// - Validate and test chart formatting logic before deployment.
// -----------------------------------------------------------------------------

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            var presentation = new Aspose.Slides.Presentation();

            // Add a bubble chart to the first slide
            var chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Bubble,
                50f, 50f, 500f, 400f);

            // Set bubble size representation to Width for proportional scaling
            chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = Aspose.Slides.Charts.BubbleSizeRepresentationType.Width;

            // Save the presentation
            presentation.Save("BubbleChartWidth.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            // format not supported
        }
    }
}
