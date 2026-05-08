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

        // Add a line chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Line, 50f, 50f, 500f, 400f);

        // Hide the horizontal (category) axis
        chart.Axes.HorizontalAxis.IsVisible = false;

        // Save the presentation
        try
        {
            presentation.Save("HideHorizontalAxis.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported or other save error
        }
    }
}