// -----------------------------------------------------------------------------
// Example: Enable smooth lines for spline chart using C#
//
// Description:
// Demonstrates how to enable smooth lines for a spline (smooth line) chart 
// using C# and Aspose.Slides for .NET. The example creates a new presentation, 
// adds a scatter chart with smooth lines (functionally a spline chart), sets 
// the series smoothing property, and saves the result as a PPTX file. This 
// pattern can be used to automate chart styling in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Enable, Smooth, Lines, Spline, 
// Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate enabling smooth lines for spline charts in presentations.
// - Build C# tools for PowerPoint chart customization.
// - Generate or modify PPTX files with styled charts in .NET applications.
// - Validate chart rendering before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
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

            // Add a scatter chart with smooth lines (acts as a spline chart)
            IChart chart = slide.Shapes.AddChart(
                Charts.ChartType.ScatterWithSmoothLines,
                50f, 50f, 500f, 400f);

            // Enable curve smoothing for the first series
            Charts.IChartSeries series = chart.ChartData.Series[0];
            series.Smooth = true;

            // Adjust tension for curve refinement
            // Note: Aspose.Slides does not expose a direct tension property.
            // This comment indicates where such adjustment would be made if available.

            // Save the presentation
            presentation.Save("SplineSmoothChart.pptx", SaveFormat.Pptx);
        }
        catch (System.IO.FileNotFoundException ex)
        {
            // Handle missing input files if any are used
            Console.WriteLine("File not found: " + ex.Message);
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., unsupported format)
            // Format not supported
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
