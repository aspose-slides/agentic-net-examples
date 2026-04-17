using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50, 50, 450, 300);

        // Disable automatic major unit calculation
        chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;

        // Set the major unit of the value axis to 10 for uniform tick spacing
        chart.Axes.VerticalAxis.MajorUnit = 10.0;

        // Save the presentation and handle possible format exceptions
        try
        {
            presentation.Save("SetMajorUnit.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // If the file format is not supported, write a comment
            // Format not supported: ex.Message
        }

        // Dispose the presentation before exiting
        presentation.Dispose();
    }
}