using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide (default slide)
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400).Chart;

        // Access the first series of the chart
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

        // Get the Y-direction error bars format (available for column charts)
        Aspose.Slides.Charts.IErrorBarsFormat errorBars = series.ErrorBarsYFormat;
        if (errorBars != null)
        {
            // Make error bars visible
            errorBars.IsVisible = true;

            // Set error bar type to show both positive and negative directions
            errorBars.Type = Aspose.Slides.Charts.ErrorBarType.Both;

            // Use a fixed value for the length of error bars
            errorBars.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Fixed;
            errorBars.Value = 0.5f; // Fixed length

            // Remove end caps from the error bars
            errorBars.HasEndCap = false;
        }

        // Save the presentation
        presentation.Save("ErrorBarsDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}