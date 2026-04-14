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

        // Add a clustered column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

        // Ensure the chart has a legend
        chart.HasLegend = true;

        // Set custom font height for the legend text
        chart.Legend.TextFormat.PortionFormat.FontHeight = 14f;

        // Save the presentation
        try
        {
            presentation.Save("ChartWithCustomLegend.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Handle unsupported format exception (if any)
        }

        // Dispose the presentation
        presentation.Dispose();
    }
}