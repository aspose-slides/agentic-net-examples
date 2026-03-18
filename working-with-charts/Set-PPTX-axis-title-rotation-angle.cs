using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a clustered column chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400, false);

            // Access the horizontal (category) axis
            IAxis horizontalAxis = chart.Axes.HorizontalAxis;

            // Set the axis title text
            horizontalAxis.Title.AddTextFrameForOverriding("Horizontal Axis Title");

            // Rotate the axis title by 45 degrees
            horizontalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 45f;

            // Save the presentation
            presentation.Save("AxisTitleRotation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}