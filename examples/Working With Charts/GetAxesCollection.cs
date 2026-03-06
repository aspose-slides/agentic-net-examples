using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 500f, 400f);

        // Get the axes manager from the chart
        Aspose.Slides.Charts.IAxesManager axesManager = chart.Axes;

        // Access individual axes
        Aspose.Slides.Charts.IAxis horizontalAxis = axesManager.HorizontalAxis;
        Aspose.Slides.Charts.IAxis verticalAxis = axesManager.VerticalAxis;
        Aspose.Slides.Charts.IAxis seriesAxis = axesManager.SeriesAxis;

        // Example: set titles for the axes
        horizontalAxis.Title.AddTextFrameForOverriding("Category Axis");
        verticalAxis.Title.AddTextFrameForOverriding("Value Axis");
        seriesAxis.Title.AddTextFrameForOverriding("Series Axis");

        // Save the presentation to a file
        presentation.Save("AxesExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation object
        presentation.Dispose();
    }
}