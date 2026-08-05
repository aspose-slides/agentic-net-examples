// -----------------------------------------------------------------------------
// Example: Save presentation as PPTX with tables and error bars using C#
//
// Description:
// Demonstrates how to create a new presentation, add a 2x2 table, insert a
// bubble chart with X and Y error bars, and save the result as a PPTX file
// using Aspose.Slides for .NET. The example includes configuring error bar
// visibility, types, and formatting, and shows basic exception handling for
// the save operation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Save, Presentation, Tables,
// Charts, Error Bars, Bubble Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate generation of PPTX files containing tables and charts with error bars.
// - Build C# tools for creating and customizing PowerPoint presentations.
// - Produce reports or dashboards that require visual data representation with error metrics.
// - Validate presentation creation workflows before deployment.
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
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a simple 2x2 table and update a cell
        Aspose.Slides.ITable table = slide.Shapes.AddTable(50f, 50f, new double[] { 100, 100 }, new double[] { 30, 30 });
        table[0, 1].TextFrame.Text = "Updated";

        // Add a bubble chart with sample data and error bars
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Bubble, 200f, 150f, 400f, 300f, true);
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

        // Configure X error bars
        Aspose.Slides.Charts.IErrorBarsFormat errorBarsX = series.ErrorBarsXFormat;
        errorBarsX.IsVisible = true;
        errorBarsX.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Fixed;
        errorBarsX.Value = 0.5f;
        errorBarsX.Type = Aspose.Slides.Charts.ErrorBarType.Plus;
        errorBarsX.HasEndCap = true;

        // Configure Y error bars
        Aspose.Slides.Charts.IErrorBarsFormat errorBarsY = series.ErrorBarsYFormat;
        errorBarsY.IsVisible = true;
        errorBarsY.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Percentage;
        errorBarsY.Value = 10f;
        errorBarsY.Format.Line.Width = 2;

        // Save the presentation as PPTX
        try
        {
            presentation.Save("ModifiedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception)
        {
            // Handle other exceptions (e.g., I/O errors)
        }

        // Dispose the presentation
        presentation.Dispose();
    }
}
