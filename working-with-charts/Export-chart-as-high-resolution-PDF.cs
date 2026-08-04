// -----------------------------------------------------------------------------
// Example: Export chart as high resolution PDF using C#
//
// Description:
// Demonstrates how to export a chart as a high‑resolution PDF using C# and 
// Aspose.Slides for .NET. The example creates a new presentation, adds a 
// clustered column chart, sets the vertical axis display unit to millions, 
// configures PDF export options for 300 DPI resolution, and saves the result 
// as a PDF file. This pattern can be used to automate PPTX workflows, 
// validate chart rendering, or integrate presentation processing into .NET 
// applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Export, Chart, High, 
// Resolution, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate export of charts to high‑resolution PDF files.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files with chart content in .NET applications.
// - Validate presentation workflows before publishing or integration.
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
        // Output PDF file path
        string outputPdfPath = "ChartHighRes.pdf";

        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a clustered column chart to the first slide
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

            // Set vertical axis display unit to millions (demonstrates display unit label)
            chart.Axes.VerticalAxis.DisplayUnit = Aspose.Slides.Charts.DisplayUnitType.Millions;

            // Configure PDF export options for high resolution
            Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
            pdfOptions.SufficientResolution = 300; // DPI

            // Save the presentation as a PDF with the specified options
            presentation.Save(outputPdfPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception)
        {
            // Handle other exceptions
        }
    }
}
