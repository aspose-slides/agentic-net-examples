// -----------------------------------------------------------------------------
// Example: Export presentation to PDF with tables and errorbars using C#
//
// Description:
// Demonstrates how to create a bubble chart with X and Y error bars and export
// the presentation to PDF while preserving OLE data such as tables using
// Aspose.Slides for .NET. The example shows the required steps for chart creation,
// error bar configuration, and PDF export with OLE inclusion in a standalone
// console application. Developers can use this pattern to automate PPTX workflows,
// generate PDF reports, or integrate presentation processing into .NET apps.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Export, Presentation,
// Charts, Bubble Chart, Error Bars, OLE Data, Tables, Office Automation
//
// Use Cases:
// - Automate export of presentations containing charts and tables to PDF.
// - Build C# tools for generating PDF reports from PowerPoint files.
// - Preserve OLE objects (e.g., tables) when converting PPTX to PDF.
// - Integrate chart creation with error bars into .NET applications.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Add a bubble chart with error bars
                Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.Bubble,
                    50f, 50f, 600f, 400f, true);

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
                errorBarsY.Value = 10;
                errorBarsY.Format.Line.Width = 2;

                // Save the presentation as PDF, preserving OLE data (e.g., tables)
                Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
                pdfOptions.IncludeOleData = true;
                presentation.Save("Output.pdf", Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
            }
            catch (NotSupportedException ex)
            {
                // Format not supported
                Console.WriteLine("The requested format is not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
