using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Presentation pres = new Presentation())
        {
            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Add a clustered column chart
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Access the first series of the chart
            IChartSeries series = chart.ChartData.Series[0];

            // Verify that Y error bars are allowed for this chart type
            if (ChartTypeCharacterizer.IsErrorBarsYAllowed(chart.Type))
            {
                // Configure error bars
                series.ErrorBarsYFormat.Type = ErrorBarType.Both;
                series.ErrorBarsYFormat.ValueType = ErrorBarValueType.Fixed;
                series.ErrorBarsYFormat.Value = 5f;

                // Set the line width of the error bars to 2 points
                series.ErrorBarsYFormat.Format.Line.Width = 2f;
            }

            // Save the presentation
            pres.Save("ErrorBarLineWidth.pptx", SaveFormat.Pptx);
        }
    }
}