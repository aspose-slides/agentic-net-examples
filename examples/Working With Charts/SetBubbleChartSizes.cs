using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SetBubbleChartSizes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a bubble chart to the first slide
            IChart chart = presentation.Slides[0].Shapes.AddChart(
                ChartType.Bubble, 50f, 50f, 600f, 400f);

            // Set bubble size scaling (e.g., 150% of default)
            chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;

            // Set how bubble size is represented (by width)
            chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;

            // Get the first series of the chart
            IChartSeries series = chart.ChartData.Series[0];

            // Add data points with X, Y and bubble size values
            series.DataPoints.AddDataPointForBubbleSeries(10.0, 20.0, 30.0);
            series.DataPoints.AddDataPointForBubbleSeries(15.0, 25.0, 45.0);
            series.DataPoints.AddDataPointForBubbleSeries(20.0, 30.0, 60.0);

            // Show bubble size values in data labels
            series.Labels.DefaultDataLabelFormat.ShowBubbleSize = true;

            // Save the presentation
            presentation.Save("BubbleChartSizes.pptx", SaveFormat.Pptx);
        }
    }
}