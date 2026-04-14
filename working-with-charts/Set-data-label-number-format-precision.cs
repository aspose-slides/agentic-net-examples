using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a clustered column chart
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

                // Get the first series of the chart
                IChartSeries series = chart.ChartData.Series[0];

                // Enable data labels for the series
                series.Labels.DefaultDataLabelFormat.ShowValue = true;

                // Set numeric format for data labels (e.g., two decimal places)
                series.Labels.DefaultDataLabelFormat.NumberFormat = "0.00%";

                // Save the presentation
                try
                {
                    pres.Save("SetDataLabelNumberFormat.pptx", SaveFormat.Pptx);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                }
                catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
                {
                    // Handle file I/O errors
                }
            }
        }
    }
}