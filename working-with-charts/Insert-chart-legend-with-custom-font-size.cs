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
            // Access the first slide
            ISlide slide = presentation.Slides[0];
            // Add a clustered column chart
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);
            // Ensure the legend is displayed
            chart.HasLegend = true;
            // Set custom font size for the legend text
            chart.Legend.TextFormat.PortionFormat.FontHeight = 14f;
            // Save the presentation
            presentation.Save("ChartWithCustomLegend.pptx", SaveFormat.Pptx);
            // Dispose the presentation
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}