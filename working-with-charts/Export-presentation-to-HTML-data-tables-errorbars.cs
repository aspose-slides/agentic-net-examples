using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Output HTML file path
        string outputPath = "ErrorBarsPresentation.html";

        try
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Add a scatter chart with smooth lines
            IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 50f, 50f, 600f, 400f);

            // Access the first series
            IChartSeries series = chart.ChartData.Series[0];

            // Configure X error bars
            series.ErrorBarsXFormat.Type = ErrorBarType.Plus;
            series.ErrorBarsXFormat.Value = 0.2f;

            // Configure Y error bars
            series.ErrorBarsYFormat.Type = ErrorBarType.Minus;
            series.ErrorBarsYFormat.Value = 0.1f;

            // Enable data table for the chart
            chart.HasDataTable = true;

            // Export the presentation to HTML
            HtmlOptions htmlOptions = new HtmlOptions();
            pres.Save(outputPath, SaveFormat.Html, htmlOptions);
        }
        catch (NotSupportedException ex)
        {
            // Format not supported
            Console.WriteLine("The requested format is not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}