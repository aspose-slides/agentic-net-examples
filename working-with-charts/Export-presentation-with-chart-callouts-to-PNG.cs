// -----------------------------------------------------------------------------
// Example: Export presentation with chart callouts to PNG using C#
//
// Description:
// Demonstrates how to export a presentation that contains a pie chart with
// data label callouts to PNG using C# and Aspose.Slides for .NET. The example
// creates a new presentation, adds a pie chart, enables callout data labels,
// saves the presentation as PPTX, and then exports both the chart and the
// entire slide as PNG images.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Export, Presentation,
// Chart, Callouts, Pie Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate export of a chart with callouts to PNG.
// - Build C# tools for PowerPoint presentation processing that include chart
//   callouts.
// - Generate or transform PPTX files with chart visualizations in .NET
//   applications.
// - Validate chart callout appearance before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a pie chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 50, 50, 400, 300);

        // Enable data labels and display them as callouts
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

        // Save the presentation to PPTX format
        presentation.Save("ChartCalloutPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Export the chart as a PNG image
        Aspose.Slides.IImage chartImage = chart.GetImage();
        chartImage.Save("ChartCallout.png", Aspose.Slides.ImageFormat.Png);

        // Export the entire slide as a PNG image to verify callout appearance
        Aspose.Slides.IImage slideImage = slide.GetImage();
        slideImage.Save("SlideWithChart.png", Aspose.Slides.ImageFormat.Png);
    }
}
