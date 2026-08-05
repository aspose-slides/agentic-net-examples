// -----------------------------------------------------------------------------
// Example: Set error bar transparency to fifty percent using C#
//
// Description:
// Demonstrates how to set error bar transparency to fifty percent using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Error, Transparency, Fifty, 
// Percent, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate set error bar transparency to fifty percent.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "ErrorBarTransparency.pptx";

        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a bubble chart (no sample data)
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Bubble,
                50f, 50f, 500f, 400f, false);

            // Ensure there is at least one series
            if (chart.ChartData.Series.Count > 0)
            {
                Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

                // Configure X error bars (if supported)
                Aspose.Slides.Charts.IErrorBarsFormat errorBarsX = series.ErrorBarsXFormat;
                if (errorBarsX != null)
                {
                    errorBarsX.IsVisible = true;
                    errorBarsX.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Fixed;
                    errorBarsX.Value = 5f;
                    errorBarsX.Type = Aspose.Slides.Charts.ErrorBarType.Plus;
                    errorBarsX.HasEndCap = true;

                    // Set 50% transparency via alpha channel (128 out of 255)
                    errorBarsX.Format.Fill.SolidFillColor.Color = System.Drawing.Color.FromArgb(128, System.Drawing.Color.Blue);
                }

                // Configure Y error bars (if supported)
                Aspose.Slides.Charts.IErrorBarsFormat errorBarsY = series.ErrorBarsYFormat;
                if (errorBarsY != null)
                {
                    errorBarsY.IsVisible = true;
                    errorBarsY.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Percentage;
                    errorBarsY.Value = 10f;
                    errorBarsY.Type = Aspose.Slides.Charts.ErrorBarType.Plus;
                    errorBarsY.HasEndCap = true;

                    // Set 50% transparency via alpha channel (128 out of 255)
                    errorBarsY.Format.Fill.SolidFillColor.Color = System.Drawing.Color.FromArgb(128, System.Drawing.Color.Green);
                }
            }

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception)
        {
            // Handle other exceptions (e.g., file I/O, external resources)
        }
    }
}
