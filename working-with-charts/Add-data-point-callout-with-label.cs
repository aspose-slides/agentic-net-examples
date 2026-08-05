// -----------------------------------------------------------------------------
// Example: Add data point callout with label using C#
//
// Description:
// Demonstrates how to add a data point callout label to a pie chart using
// C# and Aspose.Slides for .NET. The example creates a presentation, inserts a
// pie chart, enables value display and configures the data labels to be shown
// as callouts, and saves the result as a PPTX file. This pattern can be used to
// automate chart annotation tasks in PowerPoint files.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, Pie Chart, Data Labels, Callout, 
// Presentation Automation, Office Automation
//
// Use Cases:
// - Add callout labels to chart data points programmatically.
// - Generate PowerPoint reports with annotated charts.
// - Integrate chart labeling into .NET applications.
// - Automate presentation creation workflows involving charts.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a pie chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Pie, 50f, 50f, 500f, 400f);

            // Enable value display and callout for data labels
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

            // Save the presentation
            presentation.Save("ChartCallout.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
