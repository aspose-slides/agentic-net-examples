// -----------------------------------------------------------------------------
// Example: Set data label offset from axis using C#
//
// Description:
// Demonstrates how to set the distance of data labels from the axis in a chart 
// using C# and Aspose.Slides for .NET. The example creates a presentation, adds a 
// clustered column chart, configures the horizontal axis label offset, and saves 
// the result as a PPTX file. This pattern can be used to automate PowerPoint 
// chart formatting, validate presentation output, or integrate chart customization 
// into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Data Label, Offset, Axis, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting data label offset from axis in PowerPoint charts.
// - Build C# tools for PowerPoint presentation processing and chart customization.
// - Generate or transform PPTX files with specific chart label positioning.
// - Validate chart formatting workflows before publishing or integration.
// -----------------------------------------------------------------------------
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

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a clustered column chart
            Charts.IChart chart = slide.Shapes.AddChart(
                Charts.ChartType.ClusteredColumn,
                50, 50, 400, 300);

            // Set the distance of data labels from the axis (using axis label offset)
            chart.Axes.HorizontalAxis.LabelOffset = (ushort)100; // value between 0 and 1000

            // Save the presentation
            presentation.Save("Output.pptx", SaveFormat.Pptx);
        }
        catch (System.Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
            // Format not supported
        }
    }
}
