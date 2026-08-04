// -----------------------------------------------------------------------------
// Example: Set error bars both directions for scatter using C#
//
// Description:
// Demonstrates how to set error bars in both positive and negative directions for
// the X and Y axes of a scatter chart with smooth lines using Aspose.Slides for .NET.
// The example creates a new presentation, adds a scatter chart, configures the
// error bar formats, and saves the result as a PPTX file. This pattern can be
// used to automate PowerPoint chart customizations in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Scatter Chart, Error Bars, Both Directions, Chart Customization, Presentation Processing
//
// Use Cases:
// - Automate setting error bars both directions for scatter charts.
// - Build C# tools for PowerPoint chart manipulation.
// - Generate or modify PPTX files with customized chart error bars.
// - Validate chart configurations before publishing or integration.
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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a scatter chart with smooth lines
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ScatterWithSmoothLines,
                50, 50, 400, 300);

            // Get the first series of the chart
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

            // Set error bar direction to both positive and negative for X and Y axes
            series.ErrorBarsXFormat.Type = Aspose.Slides.Charts.ErrorBarType.Both;
            series.ErrorBarsYFormat.Type = Aspose.Slides.Charts.ErrorBarType.Both;

            // Save the presentation
            presentation.Save("ScatterErrorBars.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., file I/O, unsupported format, web service errors)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
