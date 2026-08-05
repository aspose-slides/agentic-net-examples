// -----------------------------------------------------------------------------
// Example: Enable auto scaling of bubble sizes using C#
//
// Description:
// Demonstrates how to enable automatic scaling of bubble sizes in a bubble
// chart using C# and Aspose.Slides for .NET. The example creates a new
// presentation, adds a bubble chart, sets the bubble size scaling factor,
// and saves the result as a PPTX file. This pattern can be used to automate
// chart formatting tasks, customize visualizations, or integrate chart
// manipulation into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Enable, Auto, Scaling, Bubble,
// Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate enabling auto scaling of bubble sizes in PowerPoint charts.
// - Build C# tools for customizing chart appearance in presentations.
// - Generate or modify PPTX files with specific bubble chart settings.
// - Validate and test chart formatting workflows before deployment.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a bubble chart to the first slide
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Bubble, 50, 50, 600, 400);

            // Enable automatic scaling of bubble sizes (example: 150% of default size)
            chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;

            // Save the presentation
            presentation.Save("BubbleChartScaling.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format, file I/O errors)
            // Format not supported or other error
        }
    }
}
