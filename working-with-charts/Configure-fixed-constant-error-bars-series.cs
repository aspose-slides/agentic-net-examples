using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            // Path to the output presentation
            string outputPath = "ErrorBarsChart.pptx";

            try
            {
                // Create a new presentation
                using (Presentation pres = new Presentation())
                {
                    // Access the first slide
                    ISlide slide = pres.Slides[0];

                    // Add a clustered column chart
                    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 400);

                    // Ensure there is at least one series
                    if (chart.ChartData.Series.Count > 0)
                    {
                        // Get the first series
                        IChartSeries series = chart.ChartData.Series[0];

                        // Configure fixed constant error bars (Y direction) with a value of 0.2
                        IErrorBarsFormat errorBars = series.ErrorBarsYFormat;
                        errorBars.ValueType = ErrorBarValueType.Fixed;
                        errorBars.Value = 0.2f;
                        errorBars.IsVisible = true;
                    }

                    // Save the presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file I/O, Aspose.Slides errors)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}