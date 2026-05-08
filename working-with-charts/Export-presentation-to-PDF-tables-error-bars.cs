using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPdf = "output.pdf";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Add a bubble chart with error bars (using add-error-bars rule)
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Bubble,
                50f, 50f, 600f, 400f, true);
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];
            Aspose.Slides.Charts.IErrorBarsFormat errorBarsX = series.ErrorBarsXFormat;
            errorBarsX.IsVisible = true;
            errorBarsX.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Fixed;
            errorBarsX.Value = 0.5f;
            errorBarsX.Type = Aspose.Slides.Charts.ErrorBarType.Plus;
            errorBarsX.HasEndCap = true;
            Aspose.Slides.Charts.IErrorBarsFormat errorBarsY = series.ErrorBarsYFormat;
            errorBarsY.IsVisible = true;
            errorBarsY.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Percentage;
            errorBarsY.Value = 10;
            errorBarsY.Format.Line.Width = 2;

            // Set PDF options to include OLE data (preserve tables)
            Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
            pdfOptions.IncludeOleData = true;

            // Save the presentation as PDF
            presentation.Save(outputPdf, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
        }
        catch (NotSupportedException ex)
        {
            // Format not supported
            Console.WriteLine("The specified format is not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}