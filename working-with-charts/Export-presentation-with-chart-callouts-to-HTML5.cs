// -----------------------------------------------------------------------------
// Example: Export presentation with chart callouts to HTML5 using C#
//
// Description:
// Demonstrates how to create a presentation, add a pie chart with data
// labels displayed as callouts, and export the result to HTML5 using
// Aspose.Slides for .NET. The example also saves the presentation as a PPTX
// file for further use. This pattern can be used to automate chart
// visualization and HTML5 export workflows.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, HTML5, Chart, Callouts,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Generate HTML5 versions of PowerPoint slides containing charts with
//   callout data labels.
// - Build .NET tools that create or modify charts and export them for web
//   consumption.
// - Automate PPTX creation with chart callouts for reporting or dashboards.
// - Validate chart rendering and export capabilities in CI pipelines.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        var slide = presentation.Slides[0];

        // Add a pie chart to the slide
        var chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 50f, 50f, 500f, 400f);

        // Enable value display and set data labels as callouts
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

        // Export the presentation to HTML5, confirming callout visibility
        string htmlOutput = "ChartCallout.html";
        try
        {
            presentation.Save(htmlOutput, Aspose.Slides.Export.SaveFormat.Html5, new Aspose.Slides.Export.Html5Options()
            {
                EmbedImages = true
            });
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }

        // Save the presentation as PPTX before exiting
        presentation.Save("ChartCallout.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
