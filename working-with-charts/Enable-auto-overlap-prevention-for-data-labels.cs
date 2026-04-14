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

        // Add a pie chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 50, 50, 500, 400);

        // Enable data labels to show values
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

        // Automatic overlapping prevention for data labels is not available via OverlapMode in the current API
        // chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.OverlapMode = Aspose.Slides.Charts.OverlapMode.Auto; // Not supported

        // Save the presentation
        try
        {
            presentation.Save("EnableAutoOverlap.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }

        // Dispose the presentation
        presentation.Dispose();
    }
}