using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace ChartPdfExport
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPdfPath = "ChartsExport.pdf";

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Add a line chart with sample data
                IChart chart = slide.Shapes.AddChart(ChartType.Line, 50f, 50f, 500f, 300f);

                // Verify that each series has a trend lines collection
                foreach (ChartSeries series in chart.ChartData.Series)
                {
                    if (series.TrendLines == null)
                    {
                        Console.WriteLine("Series does not contain a trend lines collection.");
                    }
                    else
                    {
                        Console.WriteLine("Series trend lines count: " + series.TrendLines.Count);
                    }
                }

                // Save the presentation as PDF with default options
                PdfOptions pdfOptions = new PdfOptions();
                presentation.Save(outputPdfPath, SaveFormat.Pdf, pdfOptions);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The requested format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}