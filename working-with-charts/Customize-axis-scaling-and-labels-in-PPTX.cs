using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace CustomChartAxisDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a clustered column chart
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

            // Set vertical axis display unit to Millions
            chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;

            // Set horizontal axis label offset (distance from axis) to 200 (0.2%)
            chart.Axes.HorizontalAxis.LabelOffset = (ushort)200;

            // Position horizontal axis between categories
            chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

            // Save the presentation
            presentation.Save("CustomChartAxis.pptx", SaveFormat.Pptx);
        }
    }
}