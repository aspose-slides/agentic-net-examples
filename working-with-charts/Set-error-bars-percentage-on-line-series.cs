using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a line chart to the slide
                IChart chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 600, 400);

                // Get the first series of the chart
                IChartSeries series = chart.ChartData.Series[0];

                // Configure error bars for the Y direction
                IErrorBarsFormat errorBarsY = series.ErrorBarsYFormat;
                errorBarsY.IsVisible = true;
                errorBarsY.ValueType = ErrorBarValueType.Percentage;
                errorBarsY.Value = 5; // 5 percent
                errorBarsY.Type = ErrorBarType.Both;

                // Save the presentation
                presentation.Save("LineChartErrorBars.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported
            }
        }
    }
}