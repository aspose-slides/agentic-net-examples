// -----------------------------------------------------------------------------
// Example: Export chart with callouts to PDF A using C#
//
// Description:
// Demonstrates how to export a pie chart with data label callouts to a PDF/A-2a
// file using C# and Aspose.Slides for .NET. The example creates a presentation,
// adds a pie chart, enables value display and callout labels, configures PDF/A
// compliance, and saves the result as a PDF/A document.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF/A, PDF, Export, Chart,
// Callouts, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate exporting charts with callouts to PDF/A for archival.
// - Build C# utilities for PowerPoint chart manipulation and PDF/A conversion.
// - Integrate chart export functionality into .NET applications.
// - Ensure compliance with PDF/A-2a standards when generating PDFs from PPTX.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartCalloutPdfA
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a pie chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Pie, 50, 50, 500, 400);

            // Enable value display and callout for the first series data labels
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

            // Prepare PDF/A (PDF/A-2a) export options
            Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
            pdfOptions.Compliance = Aspose.Slides.Export.PdfCompliance.PdfA2a;

            // Save the presentation as PDF/A
            string outputPath = "ChartCallout.pdf";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}
