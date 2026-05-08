using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ErrorBarsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a scatter chart with smooth lines
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ScatterWithSmoothLines,
                    50, 50, 500, 400);

                // Access the first series in the chart
                Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

                // Configure X error bars to use Standard Deviation
                series.ErrorBarsXFormat.ValueType = Aspose.Slides.Charts.ErrorBarValueType.StandardDeviation;
                series.ErrorBarsXFormat.Type = Aspose.Slides.Charts.ErrorBarType.Both;
                series.ErrorBarsXFormat.Value = 1; // Standard deviation multiplier

                // Configure Y error bars to use Standard Deviation
                series.ErrorBarsYFormat.ValueType = Aspose.Slides.Charts.ErrorBarValueType.StandardDeviation;
                series.ErrorBarsYFormat.Type = Aspose.Slides.Charts.ErrorBarType.Both;
                series.ErrorBarsYFormat.Value = 1; // Standard deviation multiplier

                // Save the presentation
                presentation.Save("ErrorBarsStandardDeviation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                // Format not supported
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}