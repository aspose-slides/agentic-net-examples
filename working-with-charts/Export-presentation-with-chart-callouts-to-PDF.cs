// -----------------------------------------------------------------------------
// Example: Export presentation with chart callouts to PDF using C#
//
// Description:
// Demonstrates how to create a PowerPoint presentation containing a pie chart
// with data labels displayed as callouts, save the presentation as PPTX, and
// then export it to PDF using Aspose.Slides for .NET. The example illustrates
// the necessary steps to add a chart, configure callout data labels, and
// perform format conversions in a standalone console application.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Export, Presentation,
// Chart, Callouts, ChartData, DataLabels, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate creation of presentations with chart callouts and export to PDF.
// - Build C# utilities for PowerPoint chart manipulation and PDF conversion.
// - Generate or transform PPTX files with customized chart labeling in .NET.
// - Validate chart callout rendering before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartCalloutExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for output files
            string pptxPath = "ChartCallout.pptx";
            string pdfPath = "ChartCallout.pdf";

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide (index 0)
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a Pie chart with sample dimensions
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Pie,
                50f,   // X position
                50f,   // Y position
                500f,  // Width
                400f   // Height
            );

            // Enable value display and show data labels as callouts for the first series
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

            // Save as PPTX (optional, demonstrates standard save)
            try
            {
                presentation.Save(pptxPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }

            // Save as PDF with default options
            try
            {
                Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
                presentation.Save(pdfPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}
