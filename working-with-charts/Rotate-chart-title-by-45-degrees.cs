using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace RotateChartTitleExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a clustered column chart to the first slide
            IChart chart = presentation.Slides[0].Shapes.AddChart(
                ChartType.ClusteredColumn,
                50f,   // X position
                50f,   // Y position
                500f,  // Width
                400f   // Height
            );

            // Ensure the chart has a title
            chart.HasTitle = true;

            // Add a title text frame and rotate the title text by 45 degrees
            chart.ChartTitle.AddTextFrameForOverriding("Rotated Title")
                 .TextFrameFormat.RotationAngle = 45f;

            // Optionally show values for the first series (demonstrates label rotation usage)
            IChartSeries series = chart.ChartData.Series[0];
            series.Labels.DefaultDataLabelFormat.ShowValue = true;

            // Save the presentation
            presentation.Save("RotatedChartTitle.pptx", SaveFormat.Pptx);
        }
    }
}