// -----------------------------------------------------------------------------
// Example: Enable percentage labels on pie chart using C#
//
// Description:
// Demonstrates how to enable percentage data labels on a pie chart using C#
// and Aspose.Slides for .NET. The example creates a presentation, adds a pie
// chart, configures the chart to display percentage values on data labels, and
// saves the result as a PPTX file. This pattern can be used to automate PPTX
// chart formatting tasks.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Enable, Percentage, Labels,
// Pie Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate enabling percentage labels on pie charts.
// - Build C# tools for PowerPoint chart customization.
// - Generate or modify PPTX files with specific chart label settings.
// - Validate chart presentation workflows before publishing.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
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

            // Add a pie chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50f, 50f, 500f, 400f);

            // Enable showing percentages on data labels
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowPercentage = true;
            // Optionally hide the raw values if only percentages are required
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = false;

            // Save the presentation
            presentation.Save("DisplayPercentage.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
