using System;
using Aspose.Slides.Export;

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

            // Add a pie chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 50, 50, 500, 400);

            // Set the data label separator to a newline character for multi‑line labels
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.Separator = "\n";

            // Show values in data labels to demonstrate the separator effect
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

            // Save the presentation
            presentation.Save("ChartWithNewlineSeparator.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}