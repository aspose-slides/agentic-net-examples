using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace HideHorizontalAxisExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add a line chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.Line, 50f, 50f, 500f, 400f);

            // Hide the horizontal (category) axis
            chart.Axes.HorizontalAxis.IsVisible = false;

            // Save the presentation
            try
            {
                presentation.Save("HideHorizontalAxis.pptx", SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception)
            {
                // Handle other exceptions (e.g., I/O errors)
            }
        }
    }
}