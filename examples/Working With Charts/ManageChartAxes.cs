using System;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn, 0, 0, 500, 400);

            // Access the axes manager
            Aspose.Slides.Charts.IAxesManager axesManager = chart.Axes;

            // Configure the horizontal axis
            Aspose.Slides.Charts.IAxis horizontalAxis = axesManager.HorizontalAxis;
            horizontalAxis.HasTitle = true;
            horizontalAxis.Title.AddTextFrameForOverriding("Category Axis");
            horizontalAxis.IsVisible = true;

            // Configure the vertical axis
            Aspose.Slides.Charts.IAxis verticalAxis = axesManager.VerticalAxis;
            verticalAxis.HasTitle = true;
            verticalAxis.Title.AddTextFrameForOverriding("Value Axis");
            verticalAxis.IsVisible = true;
            verticalAxis.MinValue = 0;
            verticalAxis.MaxValue = 100;

            // Save the presentation
            presentation.Save("ChartAxesExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}