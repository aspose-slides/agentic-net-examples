using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartAxesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Add a clustered column chart to the first slide
                IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 400);

                // Access the chart's axes manager
                IAxesManager axesManager = chart.Axes;

                // Retrieve individual axes (read-only properties)
                IAxis horizontalAxis = axesManager.HorizontalAxis;
                IAxis verticalAxis = axesManager.VerticalAxis;
                IAxis seriesAxis = axesManager.SeriesAxis;

                // Example: set the title of the chart (optional)
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("Chart with Axes");
                chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;

                // Save the presentation to disk
                presentation.Save("ChartAxesDemo.pptx", SaveFormat.Pptx);
            }
        }
    }
}