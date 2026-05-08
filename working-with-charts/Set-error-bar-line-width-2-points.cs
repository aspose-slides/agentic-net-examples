using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            // Path to an optional input presentation
            string inputPath = "input.pptx";

            // Create or load a presentation
            if (File.Exists(inputPath))
            {
                // Load existing presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    ProcessPresentation(pres);
                }
            }
            else
            {
                // Create a new presentation
                using (Presentation pres = new Presentation())
                {
                    ProcessPresentation(pres);
                }
            }
        }

        private static void ProcessPresentation(Presentation pres)
        {
            // Ensure there is at least one slide
            if (pres.Slides.Count == 0)
            {
                pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
            }

            // Add a clustered column chart to the first slide
            IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 400);

            // Access the first series of the chart
            IChartSeries series = chart.ChartData.Series[0];

            // Get the Y‑direction error bars format (if supported by the series type)
            IErrorBarsFormat errorBars = series.ErrorBarsYFormat;

            if (errorBars != null)
            {
                // Set the line width of the error bars to 2 points
                // The Format property provides access to line formatting
                IFormat format = errorBars.Format;
                ILineFormat lineFormat = format.Line;
                lineFormat.Width = 2;
            }

            // Save the presentation (handle unsupported format exception)
            try
            {
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex) when (ex is System.Net.WebException)
            {
                // Handle external URL or web service related exceptions
            }
        }
    }
}