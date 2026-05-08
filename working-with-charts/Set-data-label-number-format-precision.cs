using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            var presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            var slide = presentation.Slides[0];

            // Add a line chart to the slide
            var chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Line, 50, 50, 450, 300);

            // Enable data labels for the first series
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

            // Define the numeric format for data labels (e.g., two decimal places as percentage)
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.NumberFormat = "0.00%";

            // Save the presentation
            presentation.Save("PrecisionDataLabel.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose resources
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle any errors (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}