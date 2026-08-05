// -----------------------------------------------------------------------------
// Example: Set error bar line style to dashed using C#
//
// Description:
// Demonstrates how to set error bar line style to dashed using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Error, Line, Style, Dashed, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate set error bar line style to dashed.
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
        // Create a new presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
        {
            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a clustered column chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50, 50, 500, 400);

            // Get the first series of the chart
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

            // Retrieve the Y-direction error bars format
            Aspose.Slides.Charts.IErrorBarsFormat errorBars = series.ErrorBarsYFormat;

            if (errorBars != null)
            {
                // Make sure error bars are visible
                errorBars.IsVisible = true;

                // Set the line dash style of the error bars to dashed
                errorBars.Format.Line.DashStyle = Aspose.Slides.LineDashStyle.Dash;
            }

            // Save the presentation
            try
            {
                pres.Save("SetErrorBarLineStyleDashed.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle save errors (e.g., unsupported format)
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}
