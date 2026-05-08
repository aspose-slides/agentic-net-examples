using System;
using Aspose.Slides.Export;

namespace HideVerticalAxisExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a line chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Line, 50f, 50f, 500f, 400f);

            // Hide the vertical axis
            chart.Axes.VerticalAxis.IsVisible = false;

            // Save the presentation
            pres.Save("HideVerticalAxis.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}