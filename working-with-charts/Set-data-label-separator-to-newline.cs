// -----------------------------------------------------------------------------
// Example: Set data label separator to newline using C#
//
// Description:
// Demonstrates how to set the data label separator to a newline character for
// chart data labels using C# and Aspose.Slides for .NET. The example creates a
// presentation, adds a clustered column chart, configures the first series'
// data label format to use a newline as the separator, and saves the result.
// This pattern can be used to customize chart label formatting in automated
// PowerPoint processing.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, Chart, Data Label, Separator, Newline,
// Presentation Automation, Office Automation
//
// Use Cases:
// - Customize chart data label formatting with newline separators.
// - Build .NET tools that generate or modify PowerPoint charts.
// - Automate PPTX creation with specific label layouts.
// - Validate chart label configurations in presentation workflows.
// -----------------------------------------------------------------------------

using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Add a clustered column chart to the first slide
        IChart chart = presentation.Slides[0].Shapes.AddChart(
            ChartType.ClusteredColumn, 50, 50, 500, 400);

        // Set the data label separator to a newline character for multi‑line labels
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.Separator = "\n";

        // Save the presentation (handle unsupported format exception)
        try
        {
            presentation.Save("ChartWithNewlineSeparator.pptx", SaveFormat.Pptx);
        }
        catch (System.Exception ex)
        {
            // Format not supported or other saving issue
            // Console.WriteLine(ex.Message);
        }

        // Dispose the presentation
        presentation.Dispose();
    }
}
