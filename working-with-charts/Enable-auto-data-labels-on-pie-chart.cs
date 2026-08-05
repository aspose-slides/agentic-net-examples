// -----------------------------------------------------------------------------
// Example: Enable auto data labels on pie chart using C#
//
// Description:
// Demonstrates how to enable auto data labels on a pie chart using C# and 
// Aspose.Slides for .NET. The example creates a new presentation, adds a pie 
// chart, configures the data labels to show values as callouts to avoid 
// overlapping text, and saves the result as a PPTX file. This pattern can be 
// used to automate PowerPoint presentation processing, validate chart 
// configurations, or integrate chart generation into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Enable, Auto, Data, Labels, 
// Pie Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate enabling auto data labels on pie charts.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files with configured chart data labels in .NET 
//   applications.
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
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a pie chart
            IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);

            // Enable data labels and set them as callouts to avoid overlapping text
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

            // Save the presentation
            presentation.Save("AutoDataLabelPieChart.pptx", SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
