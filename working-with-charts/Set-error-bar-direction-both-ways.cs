// -----------------------------------------------------------------------------
// Example: Set error bar direction both ways using C#
//
// Description:
// Demonstrates how to set error bar direction to both positive and negative
// for X and Y axes in a scatter chart with smooth lines using C# and 
// Aspose.Slides for .NET. The example creates a presentation, adds a scatter
// chart, configures error bars, and saves the file as a PPTX. This pattern can
// be used to automate chart error bar settings in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Scatter Chart, Error Bars,
// Direction, Both Positive and Negative, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting error bar direction both ways in charts.
// - Build C# tools for PowerPoint chart customization.
// - Generate or modify PPTX files with specific chart error bar configurations.
// - Validate chart error bar settings in automated workflows.
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

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a scatter chart with smooth lines
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ScatterWithSmoothLines,
            50f, 50f, 400f, 300f);

        // Get the first series of the chart
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

        // Set error bar direction to both positive and negative for X and Y axes
        series.ErrorBarsXFormat.Type = Aspose.Slides.Charts.ErrorBarType.Both;
        series.ErrorBarsYFormat.Type = Aspose.Slides.Charts.ErrorBarType.Both;

        // Save the presentation
        try
        {
            presentation.Save("ScatterErrorBars.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
    }
}
