// -----------------------------------------------------------------------------
// Example: Set error bars percentage on line series using C#
//
// Description:
// Demonstrates how to set error bars percentage on a line series using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Error, Bars, Percentage, Line, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate set error bars percentage on line series.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a line chart to the slide
                IChart chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 600, 400);

                // Get the first series of the chart
                IChartSeries series = chart.ChartData.Series[0];

                // Configure error bars for the Y direction
                IErrorBarsFormat errorBarsY = series.ErrorBarsYFormat;
                errorBarsY.IsVisible = true;
                errorBarsY.ValueType = ErrorBarValueType.Percentage;
                errorBarsY.Value = 5; // 5 percent
                errorBarsY.Type = ErrorBarType.Both;

                // Save the presentation
                presentation.Save("LineChartErrorBars.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported
            }
        }
    }
}
