// -----------------------------------------------------------------------------
// Example: Update marker style while keeping error bars in a bubble chart using C#
//
// Description:
// Demonstrates how to create a bubble chart with X and Y error bars, modify the
// marker style of the series while preserving the error bars, and save the
// presentation using Aspose.Slides for .NET. The example is a self‑contained
// console application that can be used to automate PPTX chart manipulation.
//
// Keywords:
// C#, Aspose.Slides for .NET, PowerPoint, PPTX, Bubble Chart, Error Bars, Marker
// Style, Chart Automation, Office Automation
//
// Use Cases:
// - Programmatically add bubble charts with error bars to presentations.
// - Change marker appearance without losing existing error bar settings.
// - Build .NET utilities for PowerPoint chart customization.
// - Validate and transform PPTX files in automated workflows.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        string outputPath = "ChartWithErrorBars.pptx";

        try
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Add a bubble chart with error bars (using the add-error-bars rule)
            IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 500, 400, true);
            IChartSeries series = chart.ChartData.Series[0];

            // Configure X error bars
            IErrorBarsFormat errorBarsX = series.ErrorBarsXFormat;
            errorBarsX.IsVisible = true;
            errorBarsX.ValueType = ErrorBarValueType.Fixed;
            errorBarsX.Value = 0.5f;
            errorBarsX.Type = ErrorBarType.Plus;
            errorBarsX.HasEndCap = true;

            // Configure Y error bars
            IErrorBarsFormat errorBarsY = series.ErrorBarsYFormat;
            errorBarsY.IsVisible = true;
            errorBarsY.ValueType = ErrorBarValueType.Percentage;
            errorBarsY.Value = 10;
            errorBarsY.Format.Line.Width = 2;

            // Change marker style of the series while preserving error bars
            series.Marker.Size = 10;
            series.Marker.Symbol = MarkerStyleType.Diamond;

            // Save the presentation
            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("File not found: " + ex.Message);
        }
        catch (NotSupportedException ex)
        {
            // Format not supported
            Console.WriteLine("Format not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
