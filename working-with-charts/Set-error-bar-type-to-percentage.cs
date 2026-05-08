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
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a line chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 500, 400);

            // Access the first series of the chart
            IChartSeries series = chart.ChartData.Series[0];

            // Configure Y-direction error bars
            IErrorBarsFormat errorBarsY = series.ErrorBarsYFormat;
            errorBarsY.IsVisible = true;
            errorBarsY.ValueType = ErrorBarValueType.Percentage; // Set error bar value type to Percentage
            errorBarsY.Value = 5; // 5 percent value
            errorBarsY.Type = ErrorBarType.Both; // Show error bars in both directions

            try
            {
                // Save the presentation
                presentation.Save("LineChartWithErrorBars.pptx", SaveFormat.Pptx);
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