// -----------------------------------------------------------------------------
// Example: Set error bar line dashdot style using C#
//
// Description:
// Demonstrates how to set error bar line dashdot style using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Error Bar, Line, DashDot, Style, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting error bar line dashdot style.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a line chart (scatter with smooth lines)
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ScatterWithSmoothLines,
            0, 0, 500, 400);

        // Get the first series of the chart
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

        // Make Y error bars visible
        series.ErrorBarsYFormat.IsVisible = true;

        // Set the dash style of the error bar line to DashDot
        series.ErrorBarsYFormat.Format.Line.DashStyle = Aspose.Slides.LineDashStyle.DashDot;

        // Save the presentation
        pres.Save("ErrorBarsDashDot.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
