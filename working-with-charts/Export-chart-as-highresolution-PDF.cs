// -----------------------------------------------------------------------------
// Example: Export chart as highresolution PDF using C#
//
// Description:
// Demonstrates how to export a chart as a high‑resolution PDF using C# and 
// Aspose.Slides for .NET. The example creates a presentation, adds a clustered 
// column chart, configures PDF export options for 300 DPI, and saves the result 
// as a PDF file. This pattern can be used to automate chart export workflows, 
// generate PDF reports from PowerPoint data, or integrate high‑quality 
// presentation rendering into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Export, Chart, 
// Highresolution, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate export of charts to high‑resolution PDF.
// - Build C# tools for PowerPoint presentation processing.
// - Generate PDF reports from PPTX chart data in .NET applications.
// - Validate presentation rendering before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ExportChartToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output PDF file path
            string outputPdfPath = "ChartReport.pdf";

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add a clustered column chart to the first slide
                ISlide slide = presentation.Slides[0];
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

                // (Optional) Customize chart data here if needed

                // Configure PDF export options for high resolution
                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.SufficientResolution = 300; // DPI

                // Save the presentation as a PDF
                presentation.Save(outputPdfPath, SaveFormat.Pdf, pdfOptions);

                // Dispose the presentation
                presentation.Dispose();
            }
            catch (NotSupportedException ex)
            {
                // Format not supported
                Console.WriteLine("The requested format is not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
