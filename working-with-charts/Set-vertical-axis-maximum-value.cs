using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add an Area chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.Area, 50, 50, 500, 400);

            // Disable automatic max value and set a custom maximum value for the vertical axis
            chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
            chart.Axes.VerticalAxis.MaxValue = 200.0;

            // Save the presentation
            string outPath = "ChartWithMaxValue.pptx";
            presentation.Save(outPath, SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}