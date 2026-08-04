// -----------------------------------------------------------------------------
// Example: Set error bar cap style flat using C#
//
// Description:
// Demonstrates how to set the error bar cap style to flat (no end cap) for a
// chart series using C# and Aspose.Slides for .NET. The example loads or creates
// a presentation, ensures a chart exists, configures Y‑direction error bars with
// a flat cap style, and saves the result. This pattern can be used to automate
// PowerPoint chart formatting tasks in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Error Bars, Cap Style,
// Flat, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting flat cap style on chart error bars.
// - Build C# tools for PowerPoint chart customization.
// - Generate or modify PPTX files with specific chart error bar settings.
// - Validate chart formatting workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        Aspose.Slides.Presentation presentation = null;
        try
        {
            if (File.Exists(inputPath))
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            else
            {
                presentation = new Aspose.Slides.Presentation();
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or loading errors
            Console.WriteLine("Error loading presentation: " + ex.Message);
            return;
        }

        // Ensure there is at least one slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a chart if none exists on the slide
        Aspose.Slides.Charts.IChart chart = null;
        if (slide.Shapes.Count > 0 && slide.Shapes[0] is Aspose.Slides.Charts.IChart existingChart)
        {
            chart = existingChart;
        }
        else
        {
            chart = (Aspose.Slides.Charts.IChart)slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50f, 50f, 400f, 300f);
        }

        // Get the first series of the chart
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

        // Configure Y-direction error bars
        Aspose.Slides.Charts.IErrorBarsFormat errorBars = series.ErrorBarsYFormat;
        errorBars.IsVisible = true;
        // Set flat cap style (no end cap drawn)
        errorBars.HasEndCap = false;
        // Use Fixed value type to avoid runtime exception and set a value
        errorBars.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Fixed;
        errorBars.Value = 10f;
        // Set error bar direction type (both positive and negative)
        errorBars.Type = Aspose.Slides.Charts.ErrorBarType.Both;

        // Save the presentation
        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
    }
}
