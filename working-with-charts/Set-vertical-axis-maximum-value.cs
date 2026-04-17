using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add an Area chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Area,
            50f, 50f, 500f, 400f);

        // Disable automatic max value calculation
        chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;

        // Set the vertical axis maximum value
        chart.Axes.VerticalAxis.MaxValue = 200.0;

        // Save the presentation
        string outPath = "SetVerticalAxisMaxValue.pptx";
        try
        {
            pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle format not supported or other save errors
            // Format not supported: comment for unsupported format
        }

        // Dispose the presentation
        pres.Dispose();
    }
}