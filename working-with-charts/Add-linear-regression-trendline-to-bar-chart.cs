// -----------------------------------------------------------------------------
// Example: Add linear regression trendline to bar chart using C#
//
// Description:
// Demonstrates how to add a linear regression trendline to a clustered column
// (bar) chart using C# and Aspose.Slides for .NET. The example creates a new
// presentation, inserts a bar chart, adds a linear trendline to the first
// series, customizes its appearance, and saves the result as a PPTX file.
// Developers can use this pattern to automate PPTX workflows, validate results,
// or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Linear Regression, Trendline,
// Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding linear regression trendlines to bar charts in presentations.
// - Build C# tools for PowerPoint presentation processing and analysis.
// - Generate or transform PPTX files with customized chart elements in .NET
//   applications.
// - Validate chart rendering and trendline calculations before publishing.
// -----------------------------------------------------------------------------

using System;
using System.Drawing;
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
            Presentation pres = new Presentation();

            // Add a clustered column chart (bar chart) to the first slide
            IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

            // Add a linear trend line to the first series
            ITrendline trendline = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
            trendline.DisplayEquation = false;
            trendline.DisplayRSquaredValue = false;

            // Set the trend line color to red
            trendline.Format.Line.FillFormat.FillType = FillType.Solid;
            trendline.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

            // Save the presentation
            pres.Save("BarChartWithTrendline.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
