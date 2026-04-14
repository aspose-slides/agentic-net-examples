using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a stacked column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.StackedColumn, 50f, 50f, 500f, 400f);

        // Enable displaying percentage values on data labels
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowPercentage = true;

        // Optionally also show the actual values
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

        // Save the presentation
        presentation.Save("ChartWithPercentages.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}