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