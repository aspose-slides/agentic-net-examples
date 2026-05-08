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
            Presentation presentation = new Presentation();

            // Add a bubble chart to the first slide
            IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50f, 50f, 600f, 400f);

            // Enable automatic scaling of bubble sizes based on the data range
            chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150; // Scale to 150% of default size

            // Save the presentation
            string outputPath = "BubbleChartScaling.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}