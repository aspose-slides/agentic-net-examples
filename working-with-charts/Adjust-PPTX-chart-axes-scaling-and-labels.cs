using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace ChartAxisExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Get the first slide
                    ISlide slide = presentation.Slides[0];

                    // Add a clustered column chart
                    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

                    // Configure the vertical (value) axis
                    IAxis verticalAxis = chart.Axes.VerticalAxis;
                    verticalAxis.IsAutomaticMinValue = false;
                    verticalAxis.MinValue = 0;
                    verticalAxis.IsAutomaticMaxValue = false;
                    verticalAxis.MaxValue = 100;
                    verticalAxis.IsVisible = false;
                    verticalAxis.HasTitle = true;
                    verticalAxis.Title.AddTextFrameForOverriding("Values");

                    // Configure the horizontal (category) axis
                    IAxis horizontalAxis = chart.Axes.HorizontalAxis;
                    horizontalAxis.NumberFormat = "0%";
                    horizontalAxis.TickLabelRotationAngle = -45f;
                    horizontalAxis.HasTitle = true;
                    horizontalAxis.Title.AddTextFrameForOverriding("Categories");

                    // Validate chart layout (optional)
                    chart.ValidateChartLayout();

                    // Save the presentation
                    presentation.Save("ChartAxisDemo.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}