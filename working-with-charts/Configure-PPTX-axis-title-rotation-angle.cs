using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AxisTitleRotationExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                IBaseSlide slide = presentation.Slides[0];

                // Add a clustered column chart to the slide
                IChart chart = (IChart)slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 400, 300);

                // Access the horizontal axis of the chart
                IAxis horizontalAxis = chart.Axes.HorizontalAxis;

                // Set the axis title text
                horizontalAxis.Title.AddTextFrameForOverriding("Horizontal Axis");

                // Configure the rotation angle of the axis title (45 degrees)
                horizontalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 45f;

                // Save the presentation
                presentation.Save("AxisTitleRotation.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}