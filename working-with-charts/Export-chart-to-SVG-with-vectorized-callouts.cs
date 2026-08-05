// -----------------------------------------------------------------------------
// Example: Export chart to SVG with vectorized callouts using C#
//
// Description:
// Demonstrates how to export a chart to SVG with vectorized callouts using C#
// and Aspose.Slides for .NET. The example creates a presentation, adds a pie
// chart, enables data label callouts to ensure vector paths, exports the chart
// shape to an SVG file, and saves the presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SVG, Export, Chart, Vectorized,
// Callouts, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate export of charts to SVG with vectorized callouts.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a pie chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 50f, 50f, 500f, 400f);

            // Enable callout for data labels to ensure vectorized callout paths
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

            // Export the chart shape to SVG with high-fidelity options
            Aspose.Slides.Export.SVGOptions svgOptions = Aspose.Slides.Export.SVGOptions.WYSIWYG;
            using (FileStream svgStream = File.Create("chart.svg"))
            {
                chart.WriteAsSvg(svgStream, svgOptions);
            }

            // Save the presentation before exiting
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception)
        {
            // Handle other exceptions
        }
    }
}
