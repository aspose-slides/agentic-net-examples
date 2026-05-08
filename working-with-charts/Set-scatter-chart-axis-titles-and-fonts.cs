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

            // Add a scatter chart with markers
            IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithMarkers, 50f, 50f, 500f, 400f);

            // Ensure axis titles are visible
            chart.Axes.HorizontalAxis.HasTitle = true;
            chart.Axes.VerticalAxis.HasTitle = true;

            // Set X axis title and font properties
            IChartTitle xAxisTitle = chart.Axes.HorizontalAxis.Title;
            xAxisTitle.AddTextFrameForOverriding("X Axis Title");
            xAxisTitle.TextFormat.PortionFormat.FontHeight = 14f;
            xAxisTitle.TextFormat.PortionFormat.FontBold = NullableBool.True;

            // Set Y axis title and font properties
            IChartTitle yAxisTitle = chart.Axes.VerticalAxis.Title;
            yAxisTitle.AddTextFrameForOverriding("Y Axis Title");
            yAxisTitle.TextFormat.PortionFormat.FontHeight = 14f;
            yAxisTitle.TextFormat.PortionFormat.FontBold = NullableBool.True;

            // Save the presentation
            presentation.Save("ScatterChartAxisTitles.pptx", SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}