using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a bubble chart to the first slide
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Bubble, 50, 50, 600, 400);

            // Enable automatic scaling of bubble sizes (example: 150% of default size)
            chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;

            // Save the presentation
            presentation.Save("BubbleChartScaling.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format, file I/O errors)
            // Format not supported or other error
        }
    }
}